using SQLiteDBEntity;
using SQLiteDBEntity.Entities.Master;
using SQLiteDBEntity.Entities.System;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Allfree_Application.Logics.DBAccessor
{
    public class SQLiteDBAccessor
    {
        private ApplicationDbContext _db;

        public static SQLiteDBAccessor Instance { get; private set; } = new SQLiteDBAccessor();

        public SQLiteDBAccessor()
        {
            _db = new ApplicationDbContext();
        }

        public s_master_edit_password GetMasterEditPassword(int inSystemId, string inPassword)
        {
            s_master_edit_password masterEditPassword = _db.s_master_edit_passwords
                .Where(x => x.system_id == inSystemId && x.password == inPassword)
                .FirstOrDefault();

            return masterEditPassword;
        }

        public int InsertSex(int inId, string inName)
        {
            DateTime now = DateTime.Now;

            _db.m_sexs.Add(new m_sex()
            {
                m_sex_id = inId,
                m_sex_name = inName,

                create_at = now,
                create_user = "System",
                create_program = "System",
                update_at = now,
                update_user = "System",
                update_program = "System"
            });

            int result = _db.SaveChanges();
            return result;
        }

        public List<m_sex> GetSex()
        {
            List<m_sex> sexes = _db.m_sexs.ToList();

            return sexes;
        }
    }
}
