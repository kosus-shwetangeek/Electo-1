namespace Electo.Constants
{
    public class ProcedureConstant
    {
        #region Store Procedure

        public const string SPGetUserSession = "SP_GetUserSession";
        public const string SPUpdateUserPassword = "SP_UpdateUserPassword";
        public const string SPVerifyUser = "SP_VerifyUser";
        public const string SPLoggError = "SP_LoggError";
        public const string SPGetAllStudents = "SP_GetAllStudents";
        public const string SPGetAllSenateNominees = "SP_GetAllSenateNominee";
        public const string SPGetHouseNominationsNameByHouseId = "SP_GetHouseNominationsNameByHouseId";
        public const string SPUpdateCandidateVote = "SP_UpdateCandidateVote";
        public const string SPGetVoteStatus = "SP_GetVoteStatus";
        public const string SPGetAllHouses = "SP_GetAllHouses";
        public const string SPAddDelHouses = "SP_AddUpdateDelHouses";
        public const string SPAddUpdateDelSenateDesignation = "SP_AddUpdateDelSenateDesignation";
        public const string SPAddUpdateDelHouseDesignation = "SP_AddUpdateDelHouseDesignation";
        public const string SPGetAllSenateDesignation = "SP_GetAllSenateDesignation";
        public const string SP_GetAllHouseDesignation = "SP_GetAllHouseDesignation";
        public const string SPAddUpdateDelStudent = "SP_AddUpdateDelStudent";
        public const string SPDeleteStudent = "SP_DeleteStudent";
        public const string SPGetHouseElection = "SP_GetHouseElection";
        public const string SPAddUpdateDeleteHouseElection = "SP_AddUpdateDeleteHouseElection";
        public const string SPGetSenateElection = "SP_GetSenateElection";
        public const string SPAddDeleteUpdateSenateElection = "SP_AddDeleteUpdateSenateElection";


        public const string Q_GetNextStudentId = "select (max(stud_id) + 1) as Stud_Id from tstudent";

        public const string SPGetAllHouseNominationDetails = "SP_GetAllHouseNominationDetails";
        public const string SPAddUpdateDelHouseNominationDetails = "SP_AddUpdateDelHouseNominationDetails";
        public const string SPAddUpdateDelSenateNominationDetails = "SP_AddDeleteSenateNominationDetails";

        public const string SPGetAllClasses = "SP_GetAllClasses";
        public const string SPGetAllSections = "SP_GetAllSections";
        public const string SPGetAllClassSections = "SP_GetAllClassSections";
        public const string SPAddUpdateDelClassAndSection = "SP_AddUpdateDelClassAndSection";

        #endregion Store Procedure
    }
}
