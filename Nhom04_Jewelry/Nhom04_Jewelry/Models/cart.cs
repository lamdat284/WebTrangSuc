using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom04_Jewelry.Models
{
    public class Item
    {
        ProductDB db = new ProductDB();
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int SoLuonng { get; set; }
        public string Mota { get; set; }
        public string Images { get; set; }
        public string CategoryName { get; set; }
        public int soLuongMua { get; set; }

        public Item(int mt)
        {
            ProductID = mt;
            Product s = db.Products.FirstOrDefault(t => t.ProductID == mt);
            ProductName = s.ProductName;
            Price = (double)s.Price;
            SoLuonng = SoLuonng;
            Mota = s.Descriptions;
            Images = s.Images;
            CategoryName =s.Category.CategoryName;
            soLuongMua = 1;
        }

        public Item(int mt, int sl)
        {
            ProductID = mt;
            Product s = db.Products.FirstOrDefault(t => t.ProductID == mt);
            ProductName = s.ProductName;
            Price = (double)s.Price;
            SoLuonng = SoLuonng;
            Mota = s.Descriptions;
            Images = s.Images;
            CategoryName = s.Category.CategoryName;
            soLuongMua = sl;
        }

        public decimal thanhTienTemp()
        {
            return (decimal)(soLuongMua * Price);
        }
    }
    public class GioHang
    {
        public List<Item> lstSP;

        public GioHang()
        {
            lstSP = new List<Item>();
        }
        public GioHang(int ms, int sl)
        {
            Item x = new Item(ms, sl);
            lstSP.Add(x);
        }
        public int DemSLMatHang()
        {
            return lstSP.Count();
        }

        public int Them(int ms)
        {
            Item lk = lstSP.Find(n => n.ProductID == ms);

            if (lk == null) // chua co
            {
                Item sach = new Item(ms);
                if (sach == null)
                    return -1;
                lstSP.Add(sach);
            }
            else // co roi
            {
                lk.ProductID++; // tang so luong len 1
            }
            return 1;
        }

        public int TongSLMua()
        {
            return (int)lstSP.Sum(x => x.ProductID);
        }
        public void Update_Quantity(int id, int _quantity)
        {
            var item = lstSP.Find(s => s.ProductID == id);
            if (item != null)
            {
                item.soLuongMua = _quantity;
            }
        }
        public void DeleteProduct(int id)
        {
            lstSP.RemoveAll(s => s.ProductID == id);
        }
        public void ClearCart()
        {
            lstSP.Clear();
        }
    }
}
   

    
    