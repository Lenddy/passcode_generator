// the variable Builder is an  instance of the WebApplication class
var builder = WebApplication.CreateBuilder(args);
// we are adding a so-called "service" into our application's Service Container. This makes the specified service available to the rest of your application in a number of ways
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();  // AddHttpContextAccessor gives our views direct access to session so that session data doesn't need to be repeatedly passed into the ViewBag.
builder.Services.AddSession();  // add this line before calling the builder.Build() method
// build is  
var app = builder.Build();
// we need to use  this  after we set up the app variable to be Builder to implement MVC on its entirety
app.UseSession();   // to use session
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
// "Pattern" is what allows us to specify methods of our route in our Controller files
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
