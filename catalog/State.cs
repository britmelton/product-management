namespace Catalog
{
    public partial class Product
    {
        public abstract class State
        {
            protected State(Product product)
            {
                Product = product;
            }

            protected Product Product;
            public abstract void Activate();
            public abstract void Deactivate();
            public abstract void Stage();
        }

        public class Activated : State
        {
            public Activated(Product product) : base(product) { }

            public override void Activate() { }

            public override void Deactivate()
            {
                Product.Status = ProductStatus.Deactivated;
            }

            public override void Stage() { }
        }

        public class Deactivated : State
        {
            public Deactivated(Product product) : base(product) { }

            public override void Activate()
            {
                Product.Status = ProductStatus.Activated;
            }

            public override void Deactivate() { }

            public override void Stage() { }
        }

        public class Staged : State
        {
            public Staged(Product product) : base(product) { }

            public override void Activate()
            {
                Product.Status = ProductStatus.Activated;
            }

            public override void Deactivate() { }

            public override void Stage() { }
        }
    }
}