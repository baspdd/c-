using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.DAO
{
    internal class MemberDAO
    {

        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Member> getAllMembers()
        {
            List<Member> memberList;
            try
            {
                using (var dbContext = new MyStoreContext())
                {
                    memberList = dbContext.Members.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return memberList;
        }

        public Member getMemberById(int id)
        {
            Member member = null;
            try
            {
                using (var dbContext = new MyStoreContext())
                {
                    member = dbContext.Members.FirstOrDefault(m => m.MemberId == id);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return member;
        }
        public Member getMemberByEmail(string email, string password)
        {
            Member member = null;
            try
            {
                using (var dbContext = new MyStoreContext())
                {
                    member = dbContext.Members.FirstOrDefault(m => m.Email.Equals(email) && m.Password.Equals(password));
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return member;
        }
        public void addMember(Member member)
        {
            try
            {
                Member duplicate = getMemberById(member.MemberId);
                if (duplicate == null)
                {
                    using (var dbContext = new MyStoreContext())
                    {
                        dbContext.Add(member);
                        dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("This member already exists");
            }
        }
        public void updateMember(Member member)
        {
            try
            {
                Member duplicate = getMemberById(member.MemberId);
                if (duplicate != null)
                {
                    using (var dbContext = new MyStoreContext())
                    {
                        //dbContext.Update(member);
                        dbContext.Entry<Member>(member).State = EntityState.Modified;
                        dbContext.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The member does not exist");
                }
            }
            catch (Exception)
            {

                throw new Exception("The member does not exist");
            }
        }
        public void deleteMember(Member member)
        {
            try
            {
                Member m = getMemberById(member.MemberId);
                if (m != null)
                {
                    using (var sale = new MyStoreContext())
                    {
                        sale.Members.Remove(member);
                        sale.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("The member doesn't exist");
            }
        }
    }
}
