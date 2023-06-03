using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<Member> getAllMembers();
        void addMember(Member member);
        void updateMember(Member member);
        void deleteMember(Member member);
        Member getMemberById(int id);
        Member getMemberByEmail(string email, string password);
    }
}
