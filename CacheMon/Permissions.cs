﻿using System;
using System.Security.Principal;
using System.Windows.Forms;

namespace CacheMon
{
    public static class Permissions
    {

        public static void ElevateUser()
        {
            
            
            try
            {
                WindowsIdentity ContextUser = WindowsIdentity.GetCurrent(TokenAccessLevels.Query | TokenAccessLevels.AdjustPrivileges);

                Enums.SYSTEM_LUID _luid = new Enums.SYSTEM_LUID();

                if (WinNT.GetLuidInfo(Enums.SE_PRIVILEGE.SE_PROFILE_SINGLE_PROCESS_PRIVILEGE, out _luid))
                {

                    Enums.SYSTEM_LUID_AND_ATTRIBUTES _luidAttributes = new Enums.SYSTEM_LUID_AND_ATTRIBUTES();
                    Enums.TOKEN_PRIVILEGES _tokenPrivileges = new Enums.TOKEN_PRIVILEGES();

                    IntPtr _tokenPrivilegesSize = IntPtr.Zero;

                    _luidAttributes.Luid = _luid;
                    _luidAttributes.Attributes = (uint)Enums.ADJUST_PRIVILIGE_CMD.SE_PRIVILEGE_ENABLED;

                    _tokenPrivileges.PrivilegeCount = 1;
                    _tokenPrivileges.Priviliges = new Enums.SYSTEM_LUID_AND_ATTRIBUTES[1];
                    _tokenPrivileges.Priviliges[0] = _luidAttributes;

                    if (!WinNT.UpdateChangePermissions(ContextUser, false, _tokenPrivileges))
                    {

                        var win32Exception = new InvalidOperationException("UpdatePermissions Failed!");
                        throw new InvalidOperationException("AdjustTokenPrivileges failed.", win32Exception);

                    }


                    



                }

                if (WinNT.GetLuidInfo(Enums.SE_PRIVILEGE.SE_DEBUG_PRIVILEGE, out _luid))
                {

                    Enums.SYSTEM_LUID_AND_ATTRIBUTES _luidAttributes = new Enums.SYSTEM_LUID_AND_ATTRIBUTES();
                    Enums.TOKEN_PRIVILEGES _tokenPrivileges = new Enums.TOKEN_PRIVILEGES();

                    IntPtr _tokenPrivilegesSize = IntPtr.Zero;

                    _luidAttributes.Luid = _luid;
                    _luidAttributes.Attributes = (uint)Enums.ADJUST_PRIVILIGE_CMD.SE_PRIVILEGE_ENABLED;

                    _tokenPrivileges.PrivilegeCount = 1;
                    _tokenPrivileges.Priviliges = new Enums.SYSTEM_LUID_AND_ATTRIBUTES[1];
                    _tokenPrivileges.Priviliges[0] = _luidAttributes;

                    if (!WinNT.UpdateChangePermissions(ContextUser, false, _tokenPrivileges))
                    {

                        var win32Exception = new InvalidOperationException("UpdatePermissions Failed!");
                        throw new InvalidOperationException("AdjustTokenPrivileges failed.", win32Exception);

                    }


                    



                }

                if (WinNT.GetLuidInfo(Enums.SE_PRIVILEGE.SE_INCREASE_QUOTA_PRIVILEGE, out _luid))
                {

                    Enums.SYSTEM_LUID_AND_ATTRIBUTES _luidAttributes = new Enums.SYSTEM_LUID_AND_ATTRIBUTES();
                    Enums.TOKEN_PRIVILEGES _tokenPrivileges = new Enums.TOKEN_PRIVILEGES();

                    IntPtr _tokenPrivilegesSize = IntPtr.Zero;

                    _luidAttributes.Luid = _luid;
                    _luidAttributes.Attributes = (uint)Enums.ADJUST_PRIVILIGE_CMD.SE_PRIVILEGE_ENABLED;

                    _tokenPrivileges.PrivilegeCount = 1;
                    _tokenPrivileges.Priviliges = new Enums.SYSTEM_LUID_AND_ATTRIBUTES[1];
                    _tokenPrivileges.Priviliges[0] = _luidAttributes;

                    if (!WinNT.UpdateChangePermissions(ContextUser, false, _tokenPrivileges))
                    {

                        var win32Exception = new InvalidOperationException("UpdatePermissions Failed!");
                        throw new InvalidOperationException("AdjustTokenPrivileges failed.", win32Exception);

                    }


                    



                }

                ContextUser.Dispose();
            }
            catch (Exception ex)
            {

                MessageBox.Show("WARNING:  CacheMon is unable to elevate it's permissions.  \r\nCacheMon requires to be run with Administrator rights to communicate with Windows OS.", "ERROR!", MessageBoxButtons.OK);
                
            }


            

        }




    }
}
