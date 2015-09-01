using Microsoft.Hadoop.MapReduce;
using System;
using System.Data;
using System.Data.Odbc;
using System.Web.Http;
namespace Web.Controllers
{
    public class HiveController : ApiController
    {
        //public string Get()
        //{
        //    WebHDFS hdfs = new WebHDFS("localhost", "HORTON.WHO", "50070");
        //    return hdfs.ListDir("");
        //    //return GetMapData();
        //}

        public DataSet GetHiveResult()
        {
            return GetHiveData();
        }

        private string GetMapData()
        {
            try
            {

                HadoopJobConfiguration myConfig = new HadoopJobConfiguration();
                myConfig.InputPath = "/demo/simple/in";
                myConfig.OutputFolder = "/demo/simple/out";

                //connect to cluster
                Uri myUri = new Uri("hdfs://0.0.0.0:19000");

                string userName = null;

                string passWord = null;

                //Microsoft.Hadoop.WebHDFS.WebHDFSClient.MapReduce.IHadoop myCluster = Microsoft.Hadoop.MapReduce.Hadoop.Connect(myUri, userName, passWord);
                Microsoft.Hadoop.WebHDFS.WebHDFSClient client = new Microsoft.Hadoop.WebHDFS.WebHDFSClient(myUri, userName);
                return client.GetHomeDirectory().Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return string.Empty;
        }

        private DataSet GetHiveData()
        {
            var ds = new DataSet();
            //            var conn = new OdbcConnection
            //            {
            //                ConnectionString = @"DRIVER={Microsoft Hive ODBC Driver};                                        
            //                                        Host=localhost;
            //                                        Port=10000;
            //                                        Schema=default;
            //                                        DefaultTable=table_name;
            //                                        HiveServerType=1;
            //                                        ApplySSPWithQueries=1;
            //                                        AsyncExecPollInterval=100;
            //                                        AuthMech=0;
            //                                        CAIssuedCertNamesMismatch=0;
            //                                        TrustedCerts=C:\Program Files\Microsoft Hive ODBC Driver\lib\cacerts.pem;"
            //            };

            var conn = new OdbcConnection
            {
                ConnectionString = @"DSN=Sample Hortonworks Hive DSN;Uid=hue;Pwd=;"
            };
            try
            {
                conn.Open();

                var adp = new OdbcDataAdapter("Select * from sample_08", conn);

                adp.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return ds;
        }
    }
}
