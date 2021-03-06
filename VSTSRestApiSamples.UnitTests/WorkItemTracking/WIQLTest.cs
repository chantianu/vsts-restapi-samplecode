﻿using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VstsRestApiSamples.WorkItemTracking;
using VstsRestApiSamples.ViewModels.WorkItemTracking;

namespace VstsRestApiSamples.Tests.WorkItemTracking
{
    [TestClass]
    public class WIQLTest
    {
        private IConfiguration _configuration = new Configuration();

        [TestInitialize]
        public void TestInitialize()
        {
            InitHelper.GetConfiguration(_configuration);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _configuration = null;
        }

        [TestMethod, TestCategory("REST API")]  
        public void WorkItemTracking_WIQL_RunStoredQuery_Success()
        {
            //arrange
            WIQL request = new WIQL(_configuration);

            //act
            GetWIQLRunStoredQueryResponse.WIQLResult response = request.RunStoredQuery(_configuration.Project, _configuration.QueryId);

            //assert
            if (response.HttpStatusCode == HttpStatusCode.NotFound)
            {
                Assert.Inconclusive("query '" + _configuration.QueryId + "' not found");
            }
            else
            {
                Assert.AreEqual(HttpStatusCode.OK, response.HttpStatusCode);
            }

            request = null;
        }      
    }
}
