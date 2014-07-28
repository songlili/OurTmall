﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Configuration;

namespace MyStore
{
    public class storeSync
    {
        private bool storeExist;//商店是否存在，存在为0，不存在为-1
        private SqlConnection myConnection;//声明sqlconnection对象
        private SqlDataAdapter myAdapter;
        private DataTable myData;

        //*********************************************************//
        private void pullData()
        {
            if (!storeExist)
                return;
            myAdapter.Fill(myData);//从数据库中得到
        }

        private void pushData()
        {
            if (!storeExist)
                return;
            myAdapter.Update(myData);//更新到数据库
        }

        public bool judgeIfStoreExist(string iStore)
        {
            SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM [tb_store] WHERE store_name ='" + iStore + "'", myConnection);
            new SqlCommandBuilder(adp);
            DataTable table = new DataTable();

            adp.Fill(table);
            if (table.Rows.Count == 0)
                return false;
            else
                return true;
        }
        //*********************************************************//
        public storeSync()
        {
            //构造myconnection对象
            myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString());
            myConnection.Open();
            storeExist = false;
        }

        public storeSync(String iStore)
        {
            if (iStore == "")
                return;
            //构造myconnection对象
            myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString());
            myConnection.Open();

            if (!judgeIfStoreExist(iStore))//不存在
                storeExist = false;
            else
                storeExist = true;

            if (storeExist == false)//不存在
            {
                SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM [tb_store] WHERE store_name ='" + iStore + "'", myConnection);
                DataTable table = new DataTable();
                new SqlCommandBuilder(adp);
                adp.Fill(table);
                DataRow row = table.NewRow();
                row["store_name"] = iStore;
                row["password"] = "";
                row["owner_name"] = "";
                row["telephone"] = "";
                row["email"] = "";
                row["score"] = 0;
                row["description"] = "";
                row["logo"] = "";
                table.Rows.Add(row);
                adp.Update(table);
                table.Rows.Clear();
                //adp.Fill(table);
            }
            //将用户数据储存于mydata
            storeExist = true;
            myAdapter = new SqlDataAdapter("SELECT * FROM [tb_store] WHERE store_name ='" + iStore + "'", myConnection);
            new SqlCommandBuilder(myAdapter);
            myData = new DataTable();
            pullData();
        }


        //*********************************************************//
        public long id
        {
            get
            {
                if (!storeExist)
                    throw new System.Exception("NO_EXIST");
                pullData();
                return (long)myData.Rows[0]["id"];
            }
        }

        public string store_name
        {
            get
            {
                if (!storeExist)
                    throw new System.Exception("NO_EXIST");
                pullData();
                return (string)myData.Rows[0]["store_name"];
            }
            set
            {
                if (!storeExist)
                    throw new System.Exception("NO_EXIST");
                myData.Rows[0]["store_name"] = value;
                pushData();
            }
        }

        public string password
        {
            get
            {
                if (!storeExist)
                    throw new System.Exception("NO_EXIST");
                pullData();
                return (string)myData.Rows[0]["password"];
            }
            set
            {
                if (!storeExist)
                    throw new System.Exception("NO_EXIST");
                myData.Rows[0]["password"] = value;
                pushData();
            }
        }

        public string owner_name
        {
            get
            {
                if (!storeExist)
                    throw new System.Exception("NO_EXIST");
                pullData();
                return (string)myData.Rows[0]["owner_name"];
            }
            set
            {
                if (!storeExist)
                    throw new System.Exception("NO_EXIST");
                myData.Rows[0]["owner_name"] = value;
                pushData();
            }
        }

        public string email
        {
            get
            {
                if (!storeExist)
                    throw new System.Exception("NO_EXIST");
                pullData();
                return (string)myData.Rows[0]["email"];
            }
            set
            {
                if (!storeExist)
                    throw new System.Exception("NO_EXIST");
                myData.Rows[0]["email"] = value;
                pushData();
            }
        }

        public string telephone
        {
            get
            {
                if (!storeExist)
                    throw new System.Exception("NO_EXIST");
                pullData();
                return (string)myData.Rows[0]["telephone"];
            }
            set
            {
                if (!storeExist)
                    throw new System.Exception("NO_EXIST");
                myData.Rows[0]["telephone"] = value;
                pushData();
            }
        }

        public string description
        {
            get
            {
                if (!storeExist)
                    throw new System.Exception("NO_EXIST");
                pullData();
                return (string)myData.Rows[0]["description"];
            }
            set
            {
                if (!storeExist)
                    throw new System.Exception("NO_EXIST");
                myData.Rows[0]["description"] = value;
                pushData();
            }
        }

        public int score
        {
            get
            {
                if (!storeExist)
                    throw new System.Exception("NO_EXIST");
                pullData();
                return (int)myData.Rows[0]["score"];
            }
            set
            {
                if (!storeExist)
                    throw new System.Exception("NO_EXIST");
                myData.Rows[0]["score"] = value;
                pushData();
            }
        }

        public string logo
        {
            get
            {
                if (!storeExist)
                    throw new System.Exception("NO_EXIST");
                pullData();
                return (string)myData.Rows[0]["logo"];
            }
            set
            {
                if (!storeExist)
                    throw new System.Exception("NO_EXIST");
                myData.Rows[0]["logo"] = value;
                pushData();
            }
        }
    }
}