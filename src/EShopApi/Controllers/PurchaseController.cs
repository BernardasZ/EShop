using DataModel.DbContexts;
using DataModel.Models;
using EShopApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace EShopApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PurchaseController : ControllerBase
	{
		private readonly EShopDbContext eShopDbContext;
		public PurchaseController(EShopDbContext eShopDbContext)
		{
			this.eShopDbContext = eShopDbContext;
		}

		[Route("Init")]
		[HttpGet]
		public ActionResult InitDB()
		{
			var coupons = new List<Coupon>()
			{
				new Coupon()
				{
					Barcode = "BC10000",
					Type = DataModel.Enums.CouponTypeEnum.Discount,
					Value = 50,
					ActiveFromDate = DateTime.Today.AddDays(-1),
					ActiveToDate = DateTime.Today.AddDays(1)
				},
				new Coupon()
				{
					Barcode = "BC10001",
					Type = DataModel.Enums.CouponTypeEnum.Discount,
					Value = 25,
					ActiveFromDate = DateTime.Today.AddDays(-1),
					ActiveToDate = DateTime.Today.AddDays(1)
				}
			};

			eShopDbContext.Coupons.AddRange(coupons);
			eShopDbContext.SaveChanges();

			var customer = new CustomerForm()
			{
				Name = "Testas",
				Surname = "Testaitis",
				Email = "email@mail.lt",
				Mobile = "+37060000000",
				Country = "Lietuva",
				City = "Vilnius",
				AddressLine = "Gatve g. 11",
				ZipCode = "00000"
			};

			var items = new List<Item>()
			{
				new Item()
				{
					Name = "Testas1",
					Code = "C000001",
					Price = 8,
					Quantity = 20,
					Coupons = new List<Coupon>() { coupons[0] }
				},
				new Item()
				{
					Name = "Testas2",
					Code = "C000002",
					Price = 6,
					Quantity = 20,
					Coupons = new List<Coupon>() { coupons[0] }
				},
				new Item()
				{
					Name = "Testas3",
					Code = "C000003",
					Price = 4,
					Quantity = 20,
					Coupons = new List<Coupon>() { coupons[1] }
				},
			};

			eShopDbContext.Items.AddRange(items);
			eShopDbContext.SaveChanges();

			eShopDbContext.CustomerForms.AddRange(customer);
			eShopDbContext.SaveChanges();

			return Ok();
		}

		[Route("Purchase")]
		[HttpPost]
		public ActionResult TestPurchase([FromBody] CartModel model)
		{
			//TODO: patikrinti Identity

			var now = DateTime.Now;
			var itemIds = model.Items.Select(z => z.ItemId);

			var items = eShopDbContext.Items
				.AsQueryable()
				.Include(x => x.Coupons.Where(x => x.ActiveFromDate <= now && x.ActiveToDate >= now && x.Type == DataModel.Enums.CouponTypeEnum.Discount))
				.Where(x => itemIds.Contains(x.ItemId))
				.ToList();

			if (items.Count == 0)
				throw new Exception("Not items were found");


			var customerForm = eShopDbContext.CustomerForms.AsQueryable().Where(x => x.CustomerFormId == 1).First();

			var order = new Order()
			{
				CustomerFormId = customerForm.CustomerFormId,
				Comment = string.Empty,
				OrderDate = DateTime.Now,
				Status = DataModel.Enums.OrderStatusEnum.Formed
			};

			var orderItems = new List<OrderItem>();
			var quantity = 0;

			foreach (var item in items)
			{
				quantity = model.Items.Where(x => x.ItemId == item.ItemId).FirstOrDefault().Quantity;

				if (item.Quantity - quantity > 0)
					item.Quantity -= quantity;
				else
					throw new Exception("Insufficient item quantity");

				orderItems.Add(new OrderItem()
				{				
					ItemId = item.ItemId,
					Price = item.Price,
					Discount = Math.Round(item.Price - item.Price * (1 - (item.Coupons.FirstOrDefault()?.Value ?? 0) / 100), 4),
					Quantity = quantity
				});	
			}

			try
			{
				using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew))
				{
					try
					{
						eShopDbContext.SaveChanges();
					}
					catch (DbUpdateConcurrencyException ex)
					{
						ex.Entries.ToList().ForEach(x => x.Reload());

						items
							.Where(x => ex.Entries.Select(z => (z.Entity as Item).ItemId).Contains(x.ItemId))
							.ToList()
							.ForEach(x =>
							{
								quantity = model.Items.Where(x => x.ItemId == x.ItemId).FirstOrDefault().Quantity;

								if (x.Quantity - quantity > 0)
									x.Quantity -= quantity;
								else
									throw new Exception("Insufficient item quantity");
							});

						eShopDbContext.SaveChanges();
					}

					eShopDbContext.Orders.Add(order);
					eShopDbContext.SaveChanges();

					orderItems.ForEach(x => x.OrderId = order.OrderId);

					eShopDbContext.OrderItems.AddRange(orderItems);
					eShopDbContext.SaveChanges();

					scope.Complete();
				}
			}
			catch (DbUpdateConcurrencyException ex)
			{
				throw new Exception("Insufficient item quantity");
			}
			catch (Exception ex)
			{
				throw new Exception("System Error");
			}

			return Ok();
		}
	}
}
