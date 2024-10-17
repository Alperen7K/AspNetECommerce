using Core.Entities.Concrete;
using Entities.Concrete;

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
    public static string UserOperationClaimAdded = "UserOperationClaim successfully added";
    public static string UserOperationClaimExist = "UserOperationClaim already exist";
    public static string UserOperationClaimDeleted = "UserOperationClaim deleted successfully";
    public static string UserOperationClaimUpdated = "UserOperationClaim successfully updated";
    public static string UserOperationClaimGetted = "UserOperationClaim getted successfully";
    public static string PasswordError = "Password Error, please try again.";
    public static string SuccessfullLogin = "Successfully login.";
    public static string AccessTokenCreated = "Access token created successfully";
    public static string? AuthorizationDenied = "Authorization denied, you can't access this service.";
    public static string UserOperationClaimNotFound = "UserOperationClaim could not be found";
    public static string CategoryAdded = "Category added successfully";
    public static string CategoryNotExist = "Category doesn't exist";
    public static string CategoryExist = "Category exist";
    public static string CategoryUpdated = "Category updated successfully";
    public static string CategoryDeleted = "Category deleted successfully";
    public static string CategoryListed = "Category listed successfully";
    public static string ProductAdded = "Product added successfully";
    public static string ProductsListed = "Products Listed successfully";
    public static string ProductUpdated = "Product updated successfully";
    public static string ProductExists = "Product exist";
    public static string ProductDoesNotExist = "Product doesn't exist";
    public static string ProductDeleted = "Product deleted successfully";
}