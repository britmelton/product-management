using System.Net.Http.Json;
using Api.DataContracts;

namespace Shop;

    internal class Program
    {
        // this is a work in progress
        static void Main(string[] args)
        {

            Console.WriteLine("Enter your department: catalog | sales | warehouse");
            var department = Console.ReadLine().ToLower();

            if (department is "catalog")
            {
                do
                {
                    Console.WriteLine(
                        "\n\nwhat would you like to do? Register Product | Update Product Status | Edit Name | Edit Description"
                    );
                    Console.WriteLine("or type \"done\" to exit");
                    var action = Console.ReadLine().ToLower();
                    if (action is "register product")
                    {
                        Console.WriteLine(
                            "\nyou selected register product, if this is incorrect type \"done\" to return, otherwise type \"continue\""
                        );
                        var str = Console.ReadLine().ToLower();
                        if (str is "done")
                            break;

                        Console.WriteLine("\nEnter Product Name: ");
                        var name = Console.ReadLine();
                        Console.WriteLine("\nEnter Product Description: ");
                        var description = Console.ReadLine();
                        Console.WriteLine("\nEnter Product Sku: ");
                        var sku = Console.ReadLine();

                        Console.WriteLine(
                            $"You entered: \n\t{name},\n\t{description},\n\t{sku}\n if this is correct type \"y\" otherwise type \"n\""
                        );
                        var decision = Console.ReadLine().ToLower();
                        if (decision is "y")
                        {
                            var product = RegisterProduct(name, description, sku);
                            Console.WriteLine("\nProduct Details:");
                            Console.WriteLine(
                                $"\tName: {product.Result.Name}\n\tDescription: {product.Result.Description}\n\tSku: {product.Result.Sku}\n\tStaged: {product.Result.IsStaged}\n\tActive: {product.Result.IsActive}"
                            );
                        }

                        if (decision is "n")
                        {
                            Console.WriteLine("Enter Product Name: ");
                            name = Console.ReadLine();
                            Console.WriteLine("Enter Product Description: ");
                            description = Console.ReadLine();
                            Console.WriteLine("Enter Product Sku: ");
                            sku = Console.ReadLine();

                            var product = RegisterProduct(name, description, sku);
                            Console.WriteLine("Product Details:");
                            Console.WriteLine(
                                $"\t{product.Result.Name}\n\t{product.Result.Description}\n\t{product.Result.Sku}\n\t{product.Result.IsStaged}\n\t{product.Result.IsActive}"
                            );
                        }

                        Console.ReadLine();
                    }

                    else if (action is "update product status")
                    {
                        Console.WriteLine("you selected update product status, if this is incorrect type \"done\" to return, otherwise type \"continue\"");
                        var str = Console.ReadLine().ToLower();
                        if (str is "done")
                            break;

                        Console.WriteLine("enter product's Sku: ");
                        var sku = Console.ReadLine();
                        Console.WriteLine("type product state: activate | deactivate");
                        var state = Console.ReadLine().ToLower();
                        if (state is "activate")
                        {
                            var product = UpdateStatus(state, sku);
                            Console.WriteLine("\nProduct Details:");
                            Console.WriteLine(
                                $"\tName: {product.Result.Name}\n\tDescription: {product.Result.Description}\n\tSku: {product.Result.Sku}\n\tStaged: {product.Result.IsStaged}\n\tActive: {product.Result.IsActive}"
                            );
                        }
                        else if (state is "deactivate")
                        {
                            var product = UpdateStatus(state, sku);
                            Console.WriteLine("\nProduct Details:");
                            Console.WriteLine(
                                $"\tName: {product.Result.Name}\n\tDescription: {product.Result.Description}\n\tSku: {product.Result.Sku}\n\tStaged: {product.Result.IsStaged}\n\tActive: {product.Result.IsActive}"
                            );
                        }


                    }
                    else if (action is "edit name")
                    {

                    }
                    else if (action is "edit description")
                    {

                    }
                } while (true);
            }
            else if (department is "sales")
            {

            }
            else if (department is "warehouse")
            {

            }
        }

        public static HttpClient Client = new();

        public static async Task<ProductDetails> RegisterProduct(string name, string description, string sku)
        {
            var product = new RegisterProduct(name, description, sku);

            var response = await Client.PostAsJsonAsync("https://localhost:7227/api/Product/", product);

            var newProduct = await Client.GetFromJsonAsync<ProductDetails>(response.Headers.Location);

            return newProduct;
        }

        public static async Task<ProductDetails> GetProduct(string sku)
        {
            var product = await Client.GetFromJsonAsync<ProductDetails>($"https://localhost:7227/api/Product/catalog/{sku}");
            return product;
        }

        public static async Task<ProductDetails> UpdateStatus(string state, string sku)
        {
            var product = await Client.GetFromJsonAsync<ProductDetails>($"https://localhost:7227/api/Product/catalog/{sku}");
            var updateStatusDto = new UpdateProductStatusDto(product.Id, sku);
            if (state is "activate")
                await Client.PutAsJsonAsync($"https://localhost:7227/api/Product/activate/{sku}", updateStatusDto);
            else if (state is "deactivate")
                await Client.PutAsJsonAsync($"https://localhost:7227/api/Product/deactivate/{sku}", updateStatusDto);

            var response = await Client.GetFromJsonAsync<ProductDetails>($"https://localhost:7227/api/Product/catalog/{sku}");

            return response;
        }

        public static async Task<ProductDetails> EditName(string name, string sku)
        {
            var product = await Client.GetFromJsonAsync<ProductDetails>($"https://localhost:7227/api/Product/catalog/{sku}");

            var updateStatusDto = new UpdateProductStatusDto(product.Id, sku);
            var editDto = new EditNameDto(product.Id, name, sku);

            await Client.PutAsJsonAsync($"https://localhost:7227/api/Product/name/{sku}", editDto);

            var response = await Client.GetFromJsonAsync<ProductDetails>($"https://localhost:7227/api/Product/catalog/{sku}");

            return response;
        }
    }

