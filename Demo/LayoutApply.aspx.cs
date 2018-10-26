using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Client.Publishing;
namespace Demo
{
    
    public partial class LayoutApply : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string filePath = "";
            string login = "adam.a@VerinonTechnology.onmicrosoft.com";
            string password = "verinon@2018";
            var securepassword = new SecureString();
            foreach (char c in password)
            {
                securepassword.AppendChar(c);
            }

            string siteUrl = "https://verinontechnology.sharepoint.com/sites/AppPractice/";

            ClientContext context = new ClientContext(siteUrl);
            var onlineCredentials = new SharePointOnlineCredentials(login, securepassword);
            context.Credentials = onlineCredentials;
            Web web = context.Web;
            context.ExecuteQuery();

            File file = web.GetFileByServerRelativeUrl(filePath);
            file.CheckOut();
            context.Load(web);
            context.Load(file);
            context.ExecuteQuery();
            
            context.ExecuteQuery();
            //Microsoft.SharePoint.Client.List listmylist = clientContext.Web.Lists.GetByTitle("employee");
            //clientContext.Load(listmylist);
            //clientContext.ExecuteQuery();
            var pagesList = context.Web.Lists.GetByTitle("2_Documents and Pages");
            var pageItem = pagesList.GetItemById(5);
            pageItem["PublishingPageLayout"] = new FieldUrlValue() { Url = "/sites/rworldmssite1/_catalogs/masterpage/Ricoh/OneSmallOneLargeOneSmallColumnLayout.aspx", Description = " " };
            pageItem.Update();
            context.ExecuteQuery();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<string> _urlList = new List<string>();
            _urlList.Add("http://sp2010app/subsite1");
            _urlList.Add("http://sp2010app/subsite2");
            _urlList.Add("http://sp2010app/subsite3");
            _urlList.Add("http://sp2010app/subsite4");
            _urlList.Add("http://sp2010app/subsite5");
            _urlList.Add("http://sp2010app/subsite6");



            string filePath = "";
            string login = "adam.a@VerinonTechnology.onmicrosoft.com";
            string password = "verinon@2018";
            var securepassword = new SecureString();
            foreach (char c in password)
            {
                securepassword.AppendChar(c);
            }

            string siteUrl = "https://verinontechnology.sharepoint.com/sites/AppPractice/";

            ClientContext context = new ClientContext(siteUrl);
            var onlineCredentials = new SharePointOnlineCredentials(login, securepassword);
            context.Credentials = onlineCredentials;
            Web web = context.Web;
            context.ExecuteQuery();

            //NavigationNodeCreationInformation navCreation = new NavigationNodeCreationInformation();
            //navCreation.Title = "SiteCollection";
            //navCreation.Url = "https://verinontechnology.sharepoint.com/sites/AppPractice/";
            //NavigationNode quickluncnode = context.Web.Navigation.QuickLaunch.Add(navCreation);
            //context.Load(quickluncnode);
            //context.ExecuteQuery();

            //NavigationNodeCollection navColl=


            NavigationNodeCollection quickLaunchColl = web.Navigation.QuickLaunch;
            context.Load(quickLaunchColl);
            context.ExecuteQuery();
            NavigationNodeCollection nodes;
            foreach (NavigationNode node in quickLaunchColl)
            {
                Console.WriteLine(node.Title);
                if (node.Title == "SiteCollection")
                {
                    nodes = node.Children;
                    NavigationNodeCreationInformation nodeCreation = new NavigationNodeCreationInformation();
                    nodeCreation.Title = "democs link";
                    nodeCreation.Url = "http://sps2k13sp";
                    //// Add the new navigation node to the collection
                    nodes.Add(nodeCreation);
                    context.Load(nodes);
                    context.ExecuteQuery();
                }
                

            }



            //foreach (SPNavigationNode node in currentNavNodes)
            //{
            //    HideNodes(node, _urlList, ospSite.Url);
            //    if (node.Children.Count > 0)
            //    {
            //        foreach (SPNavigationNode childNode in node.Children)
            //        {
            //            HideNodes(node, _urlList, ospSite.Url);
            //        }
            //    }
            //}


        }
    }
}