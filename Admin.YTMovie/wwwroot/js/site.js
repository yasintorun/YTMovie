// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function YTLoad(result) {    
    toastr.options.positionClass = "toast-top-center"
    if (result) {
        //let result = JSON.parse(val)
        console.log(result)
        if (result.status) {
            toastr['success'](result.message, 'Başarılı!', {
                closeButton: true,
                tapToDismiss: false
            });
        } else {
            toastr['error'](result.message, 'Hata!', {
                closeButton: true,
                tapToDismiss: false
            });
        }
    }
}