using BusinessObject.Models;
using DataAcess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public IEnumerable<Member> getAllMembers() => MemberDAO.Instance.getAllMembers();
        public void addMember(Member member) => MemberDAO.Instance.addMember(member);
        public void updateMember(Member member) => MemberDAO.Instance.updateMember(member);
        public void deleteMember(Member member) => MemberDAO.Instance.deleteMember(member);
        public Member getMemberByEmail(string email, string password) => MemberDAO.Instance.getMemberByEmail(email, password);
        public Member getMemberById(int id) => MemberDAO.Instance.getMemberById(id);
    }
}
