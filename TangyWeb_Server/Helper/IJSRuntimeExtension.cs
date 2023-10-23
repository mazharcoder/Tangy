using Microsoft.JSInterop;

namespace TangyWeb_Server.Helper;

public static class IJSRuntimeExtension
{
  public static async ValueTask ToastrSuccess(this IJSRuntime jsRuntime, string message)
  {
    await jsRuntime.InvokeVoidAsync("ShowToastr", "success", message);
  }

  public static async ValueTask ToastrFailure(this IJSRuntime jsRuntime, string message)
  {
    await jsRuntime.InvokeVoidAsync("ShowToastr", "error", message);
  }
  public static async ValueTask SweetAlertSuccess(this IJSRuntime jsRuntime, string title, string message)
  {
    await jsRuntime.InvokeVoidAsync("ShowSweetAlert", title, message, "success");
  }

  public static async ValueTask SweetAlertFailure(this IJSRuntime jsRuntime, string title, string message)
  {
    await jsRuntime.InvokeVoidAsync("ShowSweetAlert", title, message, "error");
  }

}