using Reocar.WS.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Reocar.Libraries;
using Reocar.WS.Code.ME;
using System.Web.Services.Description;
namespace test
{
    [WebService(Description = "http://schemas.xmlsoap.org/wsdl/", Namespace = "http://WebXml.com.cn/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class MeService : System.Web.Services.WebService
    {

        public static Sender sender = new Sender();
        /// <summary>
        /// 根据会员ID获取会员资料
        /// </summary>
        /// <param name="MemberID"></param>
        /// <returns>MemberProfile</returns>
        [WebMethod]
        public MemberProfile GetMemberProfileByMemberID(string MemberID)
        {
            try
            {
                using (ProxyME me = new ProxyME())
                {
                    Guid MID = new Guid(MemberID);
                    MemberProfile m = me.Client.GetMemberProfileByMemberID(sender, MID);
                    return m;
                }
            }
            catch (System.Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }

        }
        /// <summary>
        /// 根据身份证获取会员信息
        /// </summary>
        /// <param name="IDNumber"></param>
        /// <returns>MemberProfile</returns>
        [WebMethod]
        public MemberProfile GetMemberByIDNumber(string IDNumber)
        {
            try
            {
                using (ProxyME me = new ProxyME())
                {
                    MemberProfile m = me.Client.GetMemberProfileByIDNumber(sender, IDNumber);
                    return m;
                }
            }
            catch (System.Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }

        }

        /// <summary>
        /// 根据email地址获取会员资料
        /// </summary>
        /// <param name="Email"></param>
        /// <returns>MemberProfile</returns>
        [WebMethod]
        public MemberProfile GetMemberProfileByEmail(string Email)
        {
            try
            {
                using (ProxyME me = new ProxyME())
                {
                    MemberProfile m = me.Client.GetMemberProfileByEmail(sender, Email);
                    return m;
                }
            }
            catch (System.Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }

        }

        /// <summary>
        /// 根据手机号码获取会员信息
        /// </summary>
        /// <param name="Mobile"></param>
        /// <returns>MemberProfile</returns>
        [WebMethod]
        public MemberProfile GetMemberProfileByMobile(string Mobile)
        {
            try
            {
                using (ProxyME me = new ProxyME())
                {
                    MemberProfile m = me.Client.GetMemberProfileByMobile(sender, Mobile);
                    return m;
                }
            }
            catch (System.Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }

        }

        /// <summary>
        /// 根据会员ID获取会员储值与积分帐户
        /// </summary>
        /// <param name="MemberID"></param>
        /// <returns>MemberAmount</returns>
        [WebMethod]
        public MemberAmount GetMemberAmount(string MemberID)
        {
            try
            {
                using (ProxyME me = new ProxyME())
                {
                    Guid MID = new Guid(MemberID);
                    MemberAmount ma = me.Client.GetMemberAmount(sender, MID);
                    return ma;
                }
            }
            catch (System.Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }

        }
        
        

        [WebMethod]
        public string TestInfo(string IDNumber)
        {
            return IDNumber;
        }
    }
}
