using System.Data;
using Dapper;
using Kaps.Domain.Entities;

namespace Kaps.Infrastructure.Persistence;

public class KapsCreateNotificationRepository:IKapsCreateNotificationRepository
{
    private readonly DapperConnectionHelper _connectionHelper;

    public KapsCreateNotificationRepository(DapperConnectionHelper connectionHelper)
    {
        _connectionHelper = connectionHelper;
    }

    public async Task<int> AddAsync(KapsCreateNotificationEntity entity)
    {
        const string dml = @"INSERT INTO Kaps.dbo.KapsCreateNotification
					(
						 IdentityNumber, 
						 ProductCode, 
						 CurrencyCode, 
						 CreditAmount, 
						 DisbursementDate, 
						 DisbursementTime, 
						 ReservationReferenceNumber, 
						 UserInfo, 
						 IncomeInfo, 
						 InstallmentCount, 
						 ChannelInfo
						
					 )
					VALUES(
					     @IdentityNumber, 
						 @ProductCode, 
						 @CurrencyCode, 
						 @CreditAmount, 
						 @DisbursementDate, 
						 @DisbursementTime, 
						 @ReservationReferenceNumber, 
						 @UserInfo, 
						 @IncomeInfo, 
						 @InstallmentCount, 
						 @ChannelInfo
					);SELECT SCOPE_IDENTITY();";

        var parameters = new DynamicParameters();
        parameters.Add("IdentityNumber", entity.IdentityNumber, DbType.String);
        parameters.Add("ProductCode", entity.ProductCode, DbType.String);
        parameters.Add("CurrencyCode", entity.CurrencyCode, DbType.String);
        parameters.Add("CreditAmount", entity.CreditAmount, DbType.String);
        parameters.Add("DisbursementDate", entity.DisbursementDate, DbType.String);
        parameters.Add("DisbursementTime", entity.DisbursementTime, DbType.String);
        parameters.Add("ReservationReferenceNumber", entity.ReservationReferenceNumber, DbType.String);
        parameters.Add("UserInfo", entity.UserInfo, DbType.String);
        parameters.Add("IncomeInfo", entity.IncomeInfo, DbType.String);
        parameters.Add("InstallmentCount", entity.InstallmentCount, DbType.String);
        parameters.Add("ChannelInfo", entity.ChannelInfo, DbType.String);
        parameters.Add("ReferenceNumber", entity.ReferenceNumber, DbType.String);
        parameters.Add("TransactionResult", entity.TransactionResult, DbType.String);
        parameters.Add("ActiveQueryNotificationStatus", entity.ActiveQueryNotificationStatus, DbType.String);
        parameters.Add("ErrorCode", entity.ErrorCode, DbType.String);
        parameters.Add("ErrorDescription", entity.ErrorDescription, DbType.String);
        parameters.Add("SystemDate", DateTime.Now, DbType.DateTime);
        parameters.Add("UserName", entity.UserName, DbType.String);
        parameters.Add("HostName", entity.HostName, DbType.String);
        using var connection = _connectionHelper.CreateSqlConnection();
        var id = await connection.ExecuteScalarAsync<int>(dml, parameters);
        return id;
    }

    public async Task UpdateAsync(Int64 id, string errorCode, string errorDescription, string activeQueryNotificationStatus,
	    string referenceNumber, string transactionResult)
    {
	   const string dml = @" UPDATE Kaps.dbo.KapsCreateNotification
					   SET ReferenceNumber= @ReferenceNumber, 
					       TransactionResult= @TransactionResult, 
					       ErrorCode= @ErrorCode, 
					       ErrorDescription= @ErrorDescription, 
					       ActiveQueryNotificationStatus= @ActiveQueryNotificationStatus, 
					 WHERE KapsCreateNotificationId=@KapsCreateNotificationId";

        var parameters = new DynamicParameters();
        parameters.Add("ReferenceNumber", referenceNumber, DbType.String);
        parameters.Add("TransactionResult", transactionResult, DbType.String);
        parameters.Add("ActiveQueryNotificationStatus", activeQueryNotificationStatus, DbType.String);
        parameters.Add("ErrorCode", errorCode, DbType.String);
        parameters.Add("ErrorDescription", errorDescription, DbType.String);
        parameters.Add("KapsCreateNotificationId", id, DbType.Int64);
       
        using var connection = _connectionHelper.CreateSqlConnection();
        await connection.ExecuteAsync(dml, parameters);
    }
}