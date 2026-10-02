namespace AppForSEII.API.Data {
    public class SeedData {
        public static void Initialize(ApplicationDbContext dbContext, IServiceProvider serviceProvider, ILogger logger) {
            List<string> rolesNames = new List<string> { "Administrator", "Employee", "Customer" };

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            try {
                SeedRoles(roleManager, rolesNames);
            }
            catch (Exception ex) {
                logger.LogError(ex, "An error occurred seeding the roles in the Database.");
            }

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            try {
                SeedUsers(userManager, rolesNames);
            }
            catch (Exception ex) {
                logger.LogError(ex, "An error occurred seeding the Users in the Database.");
            }

 

        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager, List<string> roles) {

            foreach (string roleName in roles) {
                //it checks such role does not exist in the database 
                if (!roleManager.RoleExistsAsync(roleName).Result) {
                    IdentityRole role = new IdentityRole();
                    role.Name = roleName;
                    role.NormalizedName = roleName;
                    IdentityResult roleResult = roleManager.CreateAsync(role).Result;
                }
            }

        }

        public static void SeedUsers(UserManager<ApplicationUser> userManager, List<string> roles) {
            //first, it checks the user does not already exist in the DB
            if (userManager.FindByNameAsync("elena@uclm.es").Result == null) {
                ApplicationUser user = new ApplicationUser("1", "Elena", "Navarro Martínez", "elena@uclm.es", "Calle Don Quijote 25, La Roda (Albacete)", "625785964");
                user.EmailConfirmed = true;

                var result = userManager.CreateAsync(user, "Password1234%");
                result.Wait();

                if (result.IsCompletedSuccessfully) {
                    //administrator role
                    userManager.AddToRoleAsync(user, roles[0]).Wait();
                }
            }


            if (userManager.FindByNameAsync("peter@uclm.es").Result == null) {
                //A customer class has been defined because it has different attributes (purchase, rental, etc.)
                ApplicationUser user = new ApplicationUser("3", "Peter", "Jackson", "peter@uclm.es", "Avenida España, 3, Albacete", "685120478");
                user.EmailConfirmed = true;

                var result = userManager.CreateAsync(user, "OtherPass12$");

                result.Wait();

                if (result.IsCompletedSuccessfully) {
                    //customer role
                    userManager.AddToRoleAsync(user, roles[2]).Wait();

                }
            }

        }


        public static void SeedGenresAndBooks(ApplicationDbContext dbcontext) {
            string[] nombresGenero = ["Ciencia ficción", "Drama", "Comedia", "Tragedia"];
            List<Genero> generos = [];
            Libro libro;
            foreach (string nombreGenero in nombresGenero) {
                var genero = dbcontext.Generos.FirstOrDefault(g => g.Nombre == nombreGenero);
                if (genero == null)
                    generos.Add(new Genero(nombreGenero));
                else
                    generos.Add(genero);
            }
            if (dbcontext.Libros.FirstOrDefault(m => m.Titulo == "Cincuenta sombras de grey") == null) {
                libro = new Libro(1, "Cincuenta sombras de grey","placeholder", "E.L. James",0m, new DateTime(2011, 05, 25), new Editorial(1, "Editorial XYZ"), 8.0m, 12.0m, 10, generos[1]);
                dbcontext.Libros.Add(libro);

            }

            if (dbcontext.Libros.FirstOrDefault(m => m.Titulo == "El señor de los anillos") == null) {
                libro = new Libro(2, "El señor de los anillos","placeholder", "J.R.R. Tolkin", 0m, new DateTime(1954, 07, 29), new Editorial(2, "Editorial XYZ"), 15.0m, 18.0m, 20, generos[0]);
                dbcontext.Libros.Add(libro);
            }

            //it saves the modification of dbcontext to the database
            dbcontext.SaveChanges();

            //alternatively you may have used a raw SQL
            //dbcontext.Database.ExecuteSqlRaw("INSERT INTO [Movies] ([Id], [Title], [GenreId], [ReleaseDate], [PriceForPurchase], [QuantityForPurchase], [PriceForRenting], [QuantityForRenting]) VALUES (1, N'The lord of the rings', 1, N'2011-10-20 00:00:00', 10, 1000, 1, 100)");
            //dbcontext.Database.ExecuteSqlRaw("INSERT INTO [Movies] ([Id], [Title], [GenreId], [ReleaseDate], [PriceForPurchase], [QuantityForPurchase], [PriceForRenting], [QuantityForRenting]) VALUES (2, N'The flying castle', 2, N'2007-04-04 00:00:00', 20, 1000, 3, 10)");


            //Since EFCORE7, you can perform bulk updates with linq.
            //dbcontext.Movies.ExecuteUpdate(s => s.SetProperty(m => m.QuantityForPurchase, 10));

            //other example using existing information: add 100 to the QuantityForPurchase of each Movie
            //dbcontext.Movies.ExecuteUpdate(s => s.SetProperty(m => m.QuantityForPurchase, m=>m.QuantityForPurchase+100));

            //You can alternatively use raw SQL to perform the operation where performance is sensitive:
            //dbcontext.Database.ExecuteSqlRaw("UPDATE [Movies] SET [QuantityForPurchase] = 100");

            dbcontext.SaveChanges();


        }

        public static void SeedReposicion(ApplicationDbContext dbcontext, ApplicationUser user) {

            if (dbcontext.Reposiciones.FirstOrDefault(p => p.Id == 1) == null) {
                var libro = dbcontext.Libros.First();
                var reposicion = new Reposicion(1, 
                                            new DateTime(2026,10,1), 
                                            new Visa(1, "4168521596321254", new DateTime(2028,1,1)), 
                                            new List<ReposicionItem>());

                reposicion.ReposicionItems.Add(new ReposicionItem(libro, reposicion, 5));
                dbcontext.Reposiciones.Add(reposicion);
            }
            dbcontext.SaveChanges();

        }

         public static void SeedCompra(ApplicationDbContext dbcontext, ApplicationUser user) {

            if (dbcontext.Compras.FirstOrDefault(p => p.Id == 1) == null) {
                var libro = dbcontext.Libros.First();
                var compra = new Compra(1, 
                                            new DateTime(2026,10,1), 
                                            new Decimal (50.00), 
                                            "DESC10", 
                                            new Visa(1,"4168521596321254", new DateTime(2028,1,1)));

                compra.CompraItems.Add(new CompraItem(2, libro.Id, compra.Id));
                dbcontext.Compras.Add(compra);
            }
            dbcontext.SaveChanges();

        }




    }
}