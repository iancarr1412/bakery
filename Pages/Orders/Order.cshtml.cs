using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Bakery.Data;
using Bakery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Bakery.Pages
{
    public class OrderModel : PageModel
    {
        private BakeryContext db;
        public OrderModel(BakeryContext db) => this.db = db;
        [BindProperty(SupportsGet =true)]
        public int Id { get; set; }
        public Product Product { get; set;}
        [BindProperty, EmailAddress, Required(ErrorMessage="Please enter your email address"), Display(Name="Your Email Address")]
        public string OrderEmail { get; set; }
        [BindProperty, Required(ErrorMessage="Please supply a shipping address"), Display(Name="Shipping Address")]
        public string OrderShipping { get; set; } 
        [BindProperty, Display(Name="Quantity")]
        public int OrderQuantity { get; set; } = 1;
        public async Task OnGetAsync() =>  Product = await db.Products.FindAsync(Id);

        public async Task<IActionResult> OnPostAsync()
        {
            Product = await db.Products.FindAsync(Id);
            if(ModelState.IsValid){  
                var body = $@"<p>Thank you, we have received your order for {OrderQuantity} unit(s) of {Product.Name}!</p>
                <p>Your address is: <br/>{OrderShipping.Replace("\n", "<br/>")}</p>
                Your total is ${Product.Price * OrderQuantity}.<br/>
                We will contact you if we have questions about your order.  Thanks!<br/>";
                using(var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "iancarr1412@gmail.com",  // replace with valid value
                        Password = "13Tring86#"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    MailMessage msg = new MailMessage();
                    msg.To.Add(OrderEmail);
                    msg.Subject = "Fourth Coffee - New Order";
                    msg.Body = body;
                    msg.IsBodyHtml = true;
                    msg.From = new MailAddress("iancarr1412@gmail.com");
                    await smtp.SendMailAsync(msg);
                }                              
                return RedirectToPage("/Orders/OrderSuccess");                
            }
            return Page();
        }
    }
}