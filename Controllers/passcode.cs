using Microsoft.AspNetCore.Mvc;
public class passCode : Controller{
    [HttpGet("")]
    public IActionResult generate(){
        int? count  = HttpContext.Session.GetInt32("num"); //setting this as a variable  to use later on  as an int
        if(count == null){ //cheking if count is equals to null  we are setting count to 0
            count = 0;
        }
        count++; //incremanting count by 1
        HttpContext.Session.SetInt32("num",(int)count);//setting another session that is an int then passing count as a value of a key
        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789"; //giving a string that we are going  to select random values from
        char[] arr = new char[14];//making an array that holds max 14 values
        Random rand = new Random(); //importing random
        for(int i = 0;i <14 ;i++){ //making a loop that goes throuth the length of the string variable letter  then  selecting  14 random values
            arr[i] =  letters[rand.Next(letters.Length)];
        }
        string rstring = new string (arr);//getting the random string that got created in the arr array
        HttpContext.Session.SetString("passcode",rstring);// sending the new string rstring  to session
        return View("index"); //rendering the view
    }
}