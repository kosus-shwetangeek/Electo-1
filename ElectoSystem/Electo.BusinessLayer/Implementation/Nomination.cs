//-----------------------------------------------------------------------------------------
//
// Author       : Suraj Shenmare
// Created Date : 12/07/2015
//
//-----------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Electo.DataLayer.Entities;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace Electo.BusinessLayer.Implementation
{
    public class Nomination
    {
        Electo.DataLayer.Implementation.Nomination lNomination = new DataLayer.Implementation.Nomination();
        Nominees studNom = new Nominees();
        StudentEntity studentSession = new StudentEntity();
        List<Nominees> studNomList = new List<Nominees>();
        VotetedStudents votetedStudents = new VotetedStudents();

        public List<Nominees> GetAllSenateNominees()
        {
            //nomination = new DataLayer.Implementation.Nomination();
            return studNomList = lNomination.GetAllSenateNominees();
        }

        public Nominees GetSenateNomineesById(string studId)
        {
            //nomination = new DataLayer.Implementation.Nomination();
            return studNom = lNomination.GetSenateNomineesById(studId);
        }

        public List<Nominees> GetHouseNominations()
        {
            //nomination = new DataLayer.Implementation.Nomination();
            return studNomList = lNomination.GetHouseNominations();
        }

        public List<Nominees> GetHouseNominationsById(int houseId)
        {
            //nomination = new DataLayer.Implementation.Nomination();
            return studNomList = lNomination.GetHouseNominationsById(houseId);
        }

        public bool UpdateCandidateVote(string VoaterId, string NomineeId, string VoteType, string ColumnName)
        {
            //nomination = new DataLayer.Implementation.Nomination();
            return lNomination.UpdateCandidateVote(VoaterId,NomineeId,VoteType, ColumnName);
        }

        public VotetedStudents GetVotetedStudentsStatus(string studId)
        {
            //nomination = new DataLayer.Implementation.Nomination();
            return votetedStudents = lNomination.GetVotetedStudentsStatus(studId);
        }
    }
}
