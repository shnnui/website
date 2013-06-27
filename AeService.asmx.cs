using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Reocar.Libraries;
using Reocar.WS.Code;
using Reocar.WS.Code.AE;
namespace test
{
    [WebService(Description = "http://schemas.xmlsoap.org/wsdl/", Namespace = "http://WebXml.com.cn/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class AeService : System.Web.Services.WebService
    {
        public Sender sender = new Sender();
        
        /// <summary>
        /// 获取门店信息列表，根据条件查询
        /// </summary>
        /// <param name="IsDisabled"></param>
        /// <param name="Category"></param>
        /// <returns>SearchResult</returns>
        [WebMethod]
        public SearchResult SearchDepartment(bool IsDisabled, string Category)
        {
            try
            {
                using (ProxyAE ae = new ProxyAE())
                {
                    SearchDepartmentArgs args = new SearchDepartmentArgs();
                    args.IsDisabled = IsDisabled;
                    args.Category = Category;
                    SearchResult sr  = ae.Client.SearchDepartment(sender, args);
                    return sr;
                }
            }
            catch (System.Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 根据门店ID获取某个门店的信息
        /// </summary>
        /// <param name="departmentID"></param>
        /// <returns></returns>
        [WebMethod]
        public Department GetDepartment(string departmentID)
        {
            try
            {
                using (ProxyAE ae = new ProxyAE())
                {
                    Guid DID = new Guid(departmentID);
                    Department dp = ae.Client.GetDepartment(sender, DID);
                    return dp;
                }
            }
            catch (System.Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }




    }
}
