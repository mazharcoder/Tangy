// window.ShowToastr = (type, message) => {
//     if (type === 'success') {
//         toastr.success(message, 'Operation Successful', {timeOut: 5000});
//     }
//
//     if (type === 'error') {
//         toastr.error(message, 'Operation Failed', {timeOut: 5000});
//     }
// }

function ShowToastr(type, message) {
    if (type === 'success') {
        toastr.success(message, 'Operation Successful', { timeout: 5000 });
    }

    if (type === 'error') {
        toastr.error(message, 'Operation Failed', { timeout: 5000 });
    }
}

function ShowSweetAlert(title, message, type) {
    // Type: error
    // Type: success

    Swal.fire(
        title,
        message,
        type
    );
}

function ShowDeleteConfirmationModal() {
  $('#deleteConfirmationModal').modal('show');
}

function HideDeleteConfirmationModal() {
  $('#deleteConfirmationModal').modal('hide');
}