using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
	public class AutofacBusinessModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
			builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

			builder.RegisterType<BookManager>().As<IBookService>().SingleInstance();
			builder.RegisterType<EfBookDal>().As<IBookDal>().SingleInstance();

			builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
			builder.RegisterType<EfOrderDal>().As<IOrderDal>().SingleInstance();

			var assembly = System.Reflection.Assembly.GetExecutingAssembly();
		}
	}
}
