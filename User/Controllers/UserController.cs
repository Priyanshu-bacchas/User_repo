using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using User.Models;

namespace User.Controllers
{
    /// </summary>
    public class UserController : Controller
    {

        SqlConnection con = new SqlConnection("data source=DESKTOP-RQCP02T\\SQLEXPRESS;initial catalog=db8_18925;integrated security=true");
        // GET: User
        public ActionResult UserForm()
        {
            return View();
        }



        public void InsertUpdateUser(UserModel obj)
        {
            if (obj.uid == 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("InsertUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uname", obj.uname);
                cmd.Parameters.AddWithValue("@ucountry", obj.ucountry);
                cmd.Parameters.AddWithValue("@ustate", obj.ustate);
                cmd.Parameters.AddWithValue("@ucity", obj.ucity);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UpdateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", obj.uid);
                cmd.Parameters.AddWithValue("@uname", obj.uname);
                cmd.Parameters.AddWithValue("@ucountry", obj.ucountry);
                cmd.Parameters.AddWithValue("@ustate", obj.ustate);
                cmd.Parameters.AddWithValue("@ucity", obj.ucity);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }



        public void DeleteUser(int uid)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DeleteUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uid", uid);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public JsonResult UserEdit(int uid)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("EditUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uid", uid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }



        public JsonResult CountryGet()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("countryget", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult StateGet(int cid)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("stateget", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cid", cid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CityGet(int sid)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("cityget", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sid", sid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UserGet()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("JoinUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //jhgjhgjjjhkkjhjk

    }
}