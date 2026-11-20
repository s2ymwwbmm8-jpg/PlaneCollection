using Autofac;
using ConfectioneryFactory.Repositories.Stubs;

namespace ConfectioneryFactory.IoC;

public static class ContainerConfig
{
    public static IContainer Build()
    {
        var builder = new ContainerBuilder();

        builder.RegisterType<ProductRepositoryStub>().As<IProductRepository>().SingleInstance();
        builder.RegisterType<ComponentRepositoryStub>().As<IComponentRepository>().SingleInstance();
        builder.RegisterType<SupplierRepositoryStub>().As<ISupplierRepository>().SingleInstance();
        builder.RegisterType<ProductComponentRepositoryStub>().As<IProductComponentRepository>().SingleInstance();
        builder.RegisterType<ProductOrderRepositoryStub>().As<IProductOrderRepository>().SingleInstance();
        builder.RegisterType<ComponentOrderRepositoryStub>().As<IComponentOrderRepository>().SingleInstance();

        builder.RegisterType<MainForm>();
        builder.RegisterType<ProductListForm>();
        builder.RegisterType<ComponentListForm>();
        builder.RegisterType<SupplierListForm>();
        builder.RegisterType<ProductOrderListForm>();
        builder.RegisterType<ProductOrderAddForm>();
        builder.RegisterType<ComponentOrderListForm>();
        builder.RegisterType<ComponentOrderAddForm>();

        return builder.Build();
    }
}
