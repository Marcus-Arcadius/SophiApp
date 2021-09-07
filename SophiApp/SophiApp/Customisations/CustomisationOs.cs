﻿using Microsoft.Win32;
using SophiApp.Helpers;
using System.Threading;
using Var = SophiApp.Customisations.CustomisationVars;

namespace SophiApp.Customisations
{
    public class CustomisationOs
    {
        public static void _800(bool IsActive)
        {
            if (IsActive)
            {
                RegHelper.SetValue(RegistryHive.ClassesRoot, Var._800_MSI_EXTRACT_COMMAND, string.Empty, Var._800_MSI_EXTRACT_VALUE);
                RegHelper.SetValue(RegistryHive.ClassesRoot, Var._800_MSI_EXTRACT, Var.MUIVERB, Var._800_MSI_MUIVERB_VALUE);
                RegHelper.SetValue(RegistryHive.ClassesRoot, Var._800_MSI_EXTRACT, Var._800_MSI_ICON, Var._800_MSI_ICON_VALUE);
                return;
            }

            RegHelper.DeleteSubKeyTree(RegistryHive.ClassesRoot, Var._800_MSI_EXTRACT);
        }

        public static void _801(bool IsActive)
        {
            if (IsActive)
            {
                RegHelper.SetValue(RegistryHive.ClassesRoot, Var._801_CAB_COMMAND, string.Empty, Var._801_CAB_VALUE);
                RegHelper.SetValue(RegistryHive.ClassesRoot, Var._801_CAB_RUNAS, Var.MUIVERB, Var._801_MUIVERB_VALUE);
                RegHelper.SetValue(RegistryHive.ClassesRoot, Var._801_CAB_RUNAS, Var._801_CAB_LUA_SHIELD, string.Empty);
                return;
            }

            RegHelper.DeleteSubKeyTree(RegistryHive.ClassesRoot, Var._801_CAB_RUNAS);
        }

        public static void _802(bool IsActive)
        {
            if (IsActive)
            {
                RegHelper.DeleteKey(RegistryHive.ClassesRoot, Var._802_RUNAS_USER, Var._802_EXTENDED);
                return;
            }

            RegHelper.SetValue(RegistryHive.ClassesRoot, Var._802_RUNAS_USER, Var._802_EXTENDED, string.Empty);
        }

        public static void _803(bool IsActive)
        {
            if (IsActive)
            {
                RegHelper.DeleteKey(RegistryHive.LocalMachine, Var.SHELL_EXT_BLOCKED, Var._803_CAST_TO_DEV_GUID);
                return;
            }

            RegHelper.SetValue(RegistryHive.LocalMachine, Var.SHELL_EXT_BLOCKED, Var._803_CAST_TO_DEV_GUID, Var._803_CAST_TO_DEV_VALUE);
        }

        public static void _804(bool IsActive)
        {
            if (IsActive)
            {
                RegHelper.DeleteKey(RegistryHive.LocalMachine, Var.SHELL_EXT_BLOCKED, Var._804_SHARE_GUID);
                return;
            }

            RegHelper.SetValue(RegistryHive.LocalMachine, Var.SHELL_EXT_BLOCKED, Var._804_SHARE_GUID, string.Empty);
        }

        public static void _806(bool IsActive)
        {
            if (IsActive)
            {
                RegHelper.DeleteKey(RegistryHive.ClassesRoot, Var._806_BMP_EXT, Var.PROGRAM_ACCESS_ONLY);
                return;
            }

            RegHelper.SetValue(RegistryHive.ClassesRoot, Var._806_BMP_EXT, Var.PROGRAM_ACCESS_ONLY, string.Empty);
        }

        public static void _807(bool IsActive)
        {
            if (IsActive)
            {
                RegHelper.DeleteKey(RegistryHive.ClassesRoot, Var._807_GIF_EXT, Var.PROGRAM_ACCESS_ONLY);
                return;
            }

            RegHelper.SetValue(RegistryHive.ClassesRoot, Var._807_GIF_EXT, Var.PROGRAM_ACCESS_ONLY, string.Empty);
        }

        public static void _808(bool IsActive)
        {
            if (IsActive)
            {
                RegHelper.DeleteKey(RegistryHive.ClassesRoot, Var._808_JPE_EXT, Var.PROGRAM_ACCESS_ONLY);
                return;
            }

            RegHelper.SetValue(RegistryHive.ClassesRoot, Var._808_JPE_EXT, Var.PROGRAM_ACCESS_ONLY, string.Empty);
        }

        public static void _809(bool IsActive)
        {
            if (IsActive)
            {
                RegHelper.DeleteKey(RegistryHive.ClassesRoot, Var._809_JPEG_EXT, Var.PROGRAM_ACCESS_ONLY);
                return;
            }

            RegHelper.SetValue(RegistryHive.ClassesRoot, Var._809_JPEG_EXT, Var.PROGRAM_ACCESS_ONLY, string.Empty);
        }

        public static void _810(bool IsActive)
        {
            if (IsActive)
            {
                RegHelper.DeleteKey(RegistryHive.ClassesRoot, Var._810_JPG_EXT, Var.PROGRAM_ACCESS_ONLY);
                return;
            }

            RegHelper.SetValue(RegistryHive.ClassesRoot, Var._810_JPG_EXT, Var.PROGRAM_ACCESS_ONLY, string.Empty);
        }

        public static void _811(bool IsActive)
        {
            if (IsActive)
            {
                RegHelper.DeleteKey(RegistryHive.ClassesRoot, Var._811_PNG_EXT, Var.PROGRAM_ACCESS_ONLY);
                return;
            }

            RegHelper.SetValue(RegistryHive.ClassesRoot, Var._811_PNG_EXT, Var.PROGRAM_ACCESS_ONLY, string.Empty);
        }

        public static void _812(bool IsActive)
        {
            if (IsActive)
            {
                RegHelper.DeleteKey(RegistryHive.ClassesRoot, Var._812_TIF_EXT, Var.PROGRAM_ACCESS_ONLY);
                return;
            }

            RegHelper.SetValue(RegistryHive.ClassesRoot, Var._812_TIF_EXT, Var.PROGRAM_ACCESS_ONLY, string.Empty);
        }

        public static void _813(bool IsActive)
        {
            if (IsActive)
            {
                RegHelper.DeleteKey(RegistryHive.ClassesRoot, Var._813_TIFF_EXT, Var.PROGRAM_ACCESS_ONLY);
                return;
            }

            RegHelper.SetValue(RegistryHive.ClassesRoot, Var._813_TIFF_EXT, Var.PROGRAM_ACCESS_ONLY, string.Empty);
        }

        public static void _814(bool IsActive)
        {
            if (IsActive)
            {
                RegHelper.DeleteKey(RegistryHive.ClassesRoot, Var._814_PHOTOS_SHELL_EDIT, Var.PROGRAM_ACCESS_ONLY);
                return;
            }

            RegHelper.SetValue(RegistryHive.ClassesRoot, Var._814_PHOTOS_SHELL_EDIT, Var.PROGRAM_ACCESS_ONLY, string.Empty);
        }

        public static void _815(bool IsActive)
        {
            if (IsActive)
            {
                RegHelper.DeleteKey(RegistryHive.ClassesRoot, Var._815_PHOTOS_SHELL_VIDEO, Var.PROGRAM_ACCESS_ONLY);
                return;
            }

            RegHelper.SetValue(RegistryHive.ClassesRoot, Var._815_PHOTOS_SHELL_VIDEO, Var.PROGRAM_ACCESS_ONLY, string.Empty);
        }

        public static void _816(bool IsActive)
        {
            if (IsActive)
            {
                RegHelper.DeleteKey(RegistryHive.ClassesRoot, Var._816_IMG_SHELL_EDIT, Var.PROGRAM_ACCESS_ONLY);
                return;
            }

            RegHelper.SetValue(RegistryHive.ClassesRoot, Var._816_IMG_SHELL_EDIT, Var.PROGRAM_ACCESS_ONLY, string.Empty);
        }

        public static void _817(bool IsActive)
        {
            if (IsActive)
            {
                RegHelper.DeleteKey(RegistryHive.ClassesRoot, Var._817_BAT_SHELL_EDIT, Var.PROGRAM_ACCESS_ONLY);
                RegHelper.DeleteKey(RegistryHive.ClassesRoot, Var._817_CMD_SHELL_EDIT, Var.PROGRAM_ACCESS_ONLY);
                return;
            }

            RegHelper.SetValue(RegistryHive.ClassesRoot, Var._817_BAT_SHELL_EDIT, Var.PROGRAM_ACCESS_ONLY, string.Empty);
            RegHelper.SetValue(RegistryHive.ClassesRoot, Var._817_CMD_SHELL_EDIT, Var.PROGRAM_ACCESS_ONLY, string.Empty);
        }

        public static void _818(bool IsActive) => RegHelper.SetValue(RegistryHive.ClassesRoot, Var._818_LIB_LOCATION, string.Empty,
                                                                                IsActive ? Var._818_SHOW_VALUE : Var._818_HIDE_VALUE);

        public static void _819(bool IsActive) => RegHelper.SetValue(RegistryHive.ClassesRoot, Var._819_SEND_TO, string.Empty,
                                                                                IsActive ? Var._819_SHOW_VALUE : Var._819_HIDE_VALUE);

        public static void _820(bool IsActive)
        {
            if (IsActive)
            {
                RegHelper.DeleteKey(RegistryHive.ClassesRoot, Var._820_BITLOCKER_BDE_ELEV, Var.PROGRAM_ACCESS_ONLY);
                return;
            }

            RegHelper.SetValue(RegistryHive.ClassesRoot, Var._820_BITLOCKER_BDE_ELEV, Var.PROGRAM_ACCESS_ONLY, string.Empty);
        }

        public static void _821(bool IsActive)
        {
            if (IsActive)
            {
                RegHelper.SetValue(RegistryHive.ClassesRoot, Var._821_BMP_SHELL_NEW, Var._821_BMP_ITEM_NAME, Var._821_BMP_ITEM_VALUE, RegistryValueKind.ExpandString);
                RegHelper.SetValue(RegistryHive.ClassesRoot, Var._821_BMP_SHELL_NEW, Var._821_BMP_NULL_FILE, string.Empty);
                return;
            }

            RegHelper.DeleteSubKeyTree(RegistryHive.ClassesRoot, Var._821_BMP_SHELL_NEW);
        }

        public static void _822(bool IsActive)
        {
            if (IsActive)
            {
                RegHelper.SetValue(RegistryHive.ClassesRoot, Var._822_RTF_SHELL_NEW, Var.DATA_NAME, Var._822_DATA_VALUE);
                RegHelper.SetValue(RegistryHive.ClassesRoot, Var._822_RTF_SHELL_NEW, Var.ITEM_NAME, Var._822_ITEM_VALUE);
                return;
            }

            RegHelper.DeleteSubKeyTree(RegistryHive.ClassesRoot, Var._822_RTF_SHELL_NEW);
        }

        public static void _823(bool IsActive)
        {
            if (IsActive)
            {
                RegHelper.SetValue(RegistryHive.ClassesRoot, Var._823_ZIP_SHELL_NEW, Var.DATA_NAME, Var._823_ZIP_DATA, RegistryValueKind.Binary);
                RegHelper.SetValue(RegistryHive.ClassesRoot, Var._823_ZIP_SHELL_NEW, Var.ITEM_NAME, Var._823_ITEM_DATA, RegistryValueKind.ExpandString);
                return;
            }

            RegHelper.DeleteSubKeyTree(RegistryHive.ClassesRoot, Var._823_ZIP_SHELL_NEW);
        }

        public static void _824(bool IsActive)
        {
            if (IsActive)
            {
                RegHelper.SetValue(RegistryHive.CurrentUser, Var._824_CURRENT_EXPLORER, Var._824_PROMPT_NAME, Var._824_PROMPT_VALUE, RegistryValueKind.DWord);
                return;
            }

            RegHelper.DeleteKey(RegistryHive.CurrentUser, Var._824_CURRENT_EXPLORER, Var._824_PROMPT_NAME);
        }

        public static void _825(bool IsActive)
        {
            if (IsActive)
            {
                RegHelper.DeleteKey(RegistryHive.LocalMachine, Var._825_SOFTWARE_EXPLORER, Var._825_NO_USE_NAME);
                return;
            }

            RegHelper.SetValue(RegistryHive.LocalMachine, Var._825_SOFTWARE_EXPLORER, Var._825_NO_USE_NAME, Var._825_NO_USE_VALUE, RegistryValueKind.DWord);
        }

        //TODO: CustomisationOs - Method placeholder.
        public static void FOR_DEBUG_ONLY(bool IsActive) => Thread.Sleep(1000);
    }
}