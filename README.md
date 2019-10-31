# RugerTek.AspNetCore.BancardVPos

En el metodo ConfigureServices en el Startup

``` csharp
...
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews();
}
...
```

Agrega la siguiente linea
```csharp
services.AddBancardServices(config =>
{
    config.PublicKey = "public_key";
    config.PrivateKey = "private_key";
});
```

Para usar el entorno de staging de Bancard
```csharp
services.AddBancardServices(config =>
{
    config.PublicKey = "public_key";
    config.PrivateKey = "$private_key";
}, staging: true);
```

Despues uno puede usar la libreria desde sus controladores o servicios asi:

``` csharp
public class BancardController : Controller
{
    private readonly IBancardVPos _vPosService;

    public BancardController(IBancardVPos vPosService)
    {
        _vPosService = vPosService;
    }
}
```

## Metodos disponibles
### Single Buy
Inicia el proceso de pago
```csharp
Task<BancardResponse> SingleBuyAsync(BancardSingleBuyRequest request, CancellationToken cancellationToken = default);
```
### Cards New
Inicia el proceso de catastro de una tarjeta.
```csharp
Task<BancardResponse> CardsNew(BancardCardsNewRequest request, CancellationToken cancellationToken = default);
```
### Users Card
Operación que permite listar las tarjetas catastradas por un usuario
```csharp
Task<BancardUserCardsResponse> UsersCard(int userId, CancellationToken cancellationToken = default);
```
### Charge
Operacion que permite el pago con un token
```csharp
Task<BancardResponse> Charge(BancardChargeRequest request, CancellationToken cancellationToken = default);
```
### Delete Card
Operacion que permite eliminar una tarjeta catastrada
```csharp
Task<BancardResponse> Delete(int userId, string aliasToken, CancellationToken cancellationToken = default);
```
### Single Buy Rollback
Operación que permite cancelar el pago (anónimo o con token).
```csharp
Task<BancardResponse> SingleBuyRollback(int shopProcessId, CancellationToken cancellationToken = default);
```
### Single buy confirmation
Operación para consulta, si un pago (anónimo o con token) fue confirmado o no
```csharp
Task<BancardConfirmationResponse> GetSingleBuyConfirmation(int shopProcessId, CancellationToken cancellationToken = default);
```
### Validate single buy confirm token
Valida el token de la operacoin Sigle Buy Confirm invocada por Bancard
```csharp
Task<bool> ValidateSingleBuyConfirmToken(BancardSingleBuyConfirm request);
```

## Webhook Single buy confirm
### Ejemplo
```csharp
[HttpPost, Consumes("application/json"), Produces("application/json")]
public async Task<ActionResult<BancardSingleBuyConfirmResponse>> Bancard([FromBody] BancardSingleBuyConfirm model,
    CancellationToken cancellationToken)
{
    ...
    return Ok(new BancardSingleBuyConfirmResponse {Status = "success"});
}
```

## Notas
Esta libreria solo implementa el API de bancard
Mirar los siguientes links:

https://github.com/Bancard/bancard-checkout-js

https://comercios.bancard.com.py/documents/eCommerce_bancard_compra_simple_version_1.9.pdf
