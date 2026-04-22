using System;
using System.Collections.Generic;
using System.Text;

namespace MicroProject1.Models
{

    public static class Club
    {
        public static List<Member> members = new List<Member>()
        {
            new RegularMember { MemberID = 1, Name = "John" },
            new RegularMember { MemberID = 2, Name = "Paul" },
            new RegularMember { MemberID = 3, Name = "Tom" }
        };

        private static int nextId = 1;

        public static Member EnrollMember(string memberName)
        {
            Member member = new Member();
            member.Name = memberName;
            member.MemberID = nextId;
            nextId++;

            members.Add(member);
            return member;
        }

        public static bool PromoteToBoard(int memberId)
        {
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].MemberID == memberId)
                {
                    if (members[i] is RegularMember regular)
                    {
                        BoardMember board = new BoardMember
                        {
                            MemberID = regular.MemberID,
                            Name = regular.Name
                        };

                        members[i] = board;
                        return true;
                    }

                    return false;
                }
            }
            return false;
        }

        public static void ListMembers()
        {
            foreach (var m in members)
            {
                Console.WriteLine($"{m.MemberID} - {m.Name} - {m.GetType().Name}");
            }
        }
        public static Member GetMemberById(int memberId)
        {
            foreach (var member in members)
            {
                if (member.MemberID == memberId)
                {
                    return member;
                }
            }

            return null;
        }


    }

}
