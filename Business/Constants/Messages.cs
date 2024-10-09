using Core.Entities.Concrete;

namespace Business.Constants;

public static class Messages
{
    public const string UserRegistered = "Kullanıcı başarıyla kaydedildi.";

    public static string UserAlreadyRegistered =
        "Bu mail zaten kullanılmaktadır, lütfen başka bir email adresi deneyiniz.";

    public static string UserNotFound = "Kullanıcı bulunamadı.";

    public static string OperationClaimAdded = "OperationClaim added";
    public static string OperationClaimUpdated = "Updated successfully OperationClaim";
    public static string OperationClaimDeleted = "OperationClaim deleted successfully";
    public static string OperationClaimDidNotDeleted = "OperationClaim could not be deleted";
    public static string OperationClaimListed = "OperationClaim listed successfully";
    public static string OperationClaimExist = "OperationClaim already exist";
    public static string OperationClaimGetted = "Operation claim getted successfully";
    public static string OperationClaimNotFound = "OperationClaim could not be found";
}