using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PhotoFolioHub.Models;
using System.Data;

namespace PhotoFolioHub.Filter
{
    /// <summary>
    /// 自訂身份驗證過濾器，用於確保使用者已登入並擁有訪問權限。
    /// </summary>
    public class AuthFilter : IAuthorizationFilter
    {
        private readonly PhotoFolioHubContext _context;


        /// <summary>
        /// 初始化 AuthFilter 類別的新執行個體。
        /// </summary>
        /// <param name="context">應用程式的資料庫上下文。</param>
        public AuthFilter(PhotoFolioHubContext context)
        {
            _context = context;
        }


        /// <summary>
        /// 在執行動作方法之前執行身份驗證和權限檢查。
        /// </summary>
        /// <param name="authorizationFilterContext">授權過濾器上下文。</param>
        public void OnAuthorization(AuthorizationFilterContext authorizationFilterContext)
        {
            // 從 Session 中獲取使用者相關資訊
            string UserId = authorizationFilterContext.HttpContext.Session.GetString("UserId");
            string UserName = authorizationFilterContext.HttpContext.Session.GetString("UserName");

            // 判斷使用者是否登入
            if (string.IsNullOrEmpty(UserId) || string.IsNullOrEmpty(UserName))
            {
                // 如果未登入，將使用者重定向到登入頁面並顯示提示訊息
                authorizationFilterContext.Result = new ContentResult()
                {
                    Content = "<script>alert('尚未登入');window.location.href='/Login/Index'</script>",
                    ContentType = "text/html;charset=utf-8",
                };

                return;
            }
        }
    }

}
