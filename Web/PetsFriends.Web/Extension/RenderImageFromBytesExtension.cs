﻿namespace PetsFriends.Web.Extension
{
    using System;

    public static class RenderImageFromBytesExtension
    {
        public static string RenderPicture(this byte[] array)
        {
            if (array == null)
            {
                return string.Empty;
            }

            return "data:image; base64," + Convert.ToBase64String(array);
        }
    }
}
