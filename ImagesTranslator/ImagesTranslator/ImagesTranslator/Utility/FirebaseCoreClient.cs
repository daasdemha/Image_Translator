using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagesTranslator.Utility
{
    public sealed class FirebaseCoreClient
    {
        private static FirebaseClient instance = null;
        public FirebaseCoreClient()
        {

        }
        public static FirebaseClient Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FirebaseClient("https://imagetranslator-32054-default-rtdb.firebaseio.com/");
                }
                return instance;
            }
        }

    }
}
