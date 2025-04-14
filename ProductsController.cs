using Microsoft.AspNetCore.Mvc;
using MVC04.Data;
using MVC04.Models;

public class ProductsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductsController(ApplicationDbContext context)
    {
        _context = context;
    }

 
    public IActionResult NewProduct()
    {
        return View();
    }

   
   [HttpPost]
public IActionResult NewProduct(Product product)
{
    if (ModelState.IsValid)
    {
        _context.Products.Add(product); // Thêm sản phẩm vào DbSet
        _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
        return RedirectToAction("NewProduct"); 
    }
    return View(product); // Nếu không hợp lệ, trả về view hiện tại
}

public IActionResult ProductMgr()
{
    var products = _context.Products.ToList(); // Lấy danh sách sản phẩm từ CSDL
    return View(products); // Truyền danh sách vào view
}

[HttpPost]
public IActionResult Delete(int id)
{
    var product = _context.Products.Find(id); // Tìm sản phẩm theo ID
    if (product != null)
    {
        _context.Products.Remove(product); // Xóa sản phẩm
        _context.SaveChanges(); // Lưu thay đổi
    }
    return RedirectToAction("ProductMgr"); // Quay lại danh sách sản phẩm
}


}
