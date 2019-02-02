using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ArchieveController : Controller
    {
        public ActionResult DeleteToArchieve()
        {
            Archieve();
            return View();
        }

        public async Task Archieve()
        {
            CurContext context = new CurContext();

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Configuration.ProxyCreationEnabled = false;
                    var directory = System.Web.Hosting.HostingEnvironment.MapPath("~/Archive");
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Contract>));
                    using (FileStream fs = new FileStream($@"{directory}/Contracts_{DateTime.Now.Ticks}.json", FileMode.OpenOrCreate))
                    {
                        jsonFormatter.WriteObject(fs, await context.Contracts.Where(c => c.DateEndProduct < DateTime.Now).ToListAsync());
                    }
                    context.Contracts.RemoveRange(context.Contracts.Where(c => c.DateEndProduct < DateTime.Now));
                    await context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {

                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    context.Configuration.ProxyCreationEnabled = true;
                }
            }
        }

    }
}