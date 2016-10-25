using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for BearApp
/// </summary>
public class BearApp
{
    private static BearApp _instance = new BearApp();
    
    public static BearApp Instance 
    {
        get { return _instance; }
    }

    private BearApp()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}
