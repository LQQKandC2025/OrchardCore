using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "Customer Dashboard",
    Author = "Sen",
    Version = "1.0.0",
    Description = "Müşteri bilgilerini gösterir",
    Category = "Dashboard",
    Dependencies = new[] { "OrchardCore.Admin", "OrchardCore.Themes.TheAdmin" }
)]
