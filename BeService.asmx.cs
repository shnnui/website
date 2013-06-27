using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Reocar.WS.Code;
using Reocar.Libraries;
using Reocar.WS.Code.BE;
namespace test
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Description = "http://schemas.xmlsoap.org/wsdl/", Namespace = "http://WebXml.com.cn/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class BeService : System.Web.Services.WebService
    {
        public Sender sender = new Sender();

        /// <summary>
        /// 获取字典里的城市列表
        /// </summary>
        /// <returns>List<CategoryCode></returns>
        [WebMethod]
        public List<CategoryCode> GetCategoryCodesByCategoryCode()
        {
            try
            {
                using(ProxyBE be = new ProxyBE())
                {
                    List<CategoryCode> citys = be.Client.GetCategoryCodesByCategoryCode(sender, "City");
                    return citys;
                }
            }
            catch (System.Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 搜索字典里的信息, 例如 SearchCategoryCode(false, "City")可以搜索到可用的城市，　Areal可以搜索区域
        /// </summary>
        /// <param name="IsDisabled"></param>
        /// <param name="CategoryCode"></param>
        /// <returns>SearchResult</returns>
        [WebMethod]
        public SearchResult SearchCategoryCode(bool IsDisabled, string CategoryCode, string ExtendInfo)
        {

            try
            {
                using (ProxyBE be = new ProxyBE())
                {
                    SearchCategoryCodeArgs args = new SearchCategoryCodeArgs();
                    args.IsDisabled = IsDisabled;
                    args.CategoryCode = CategoryCode;
                    if (String.IsNullOrEmpty(ExtendInfo))
                    {
                        args.ExtendInfo = ExtendInfo;
                    }
                    SearchResult sr = be.Client.SearchCategoryCode(sender, args);
                    return sr;
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
