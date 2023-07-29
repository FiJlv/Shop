function Remove(carId) {
    $.ajax({
        type: 'POST',
        url: '/FavoriteCars/Remove',
        data: { id: carId },
        success: function (result) {
            location.reload();
        },
        error: function () {
        }
    });
}

function addToFavorites(carId) {
    $.ajax({
        type: 'POST',
        url: '/FavoriteCars/Add',
        data: { id: carId },
        success: function (result) {
            toastr.options = {
                closeButton: true,
                progressBar: true,
                timeOut: 500,
                positionClass: 'toast-bottom-right',
                onShown: function () {
                    const toast = document.querySelector('.toast-bottom-right');
                }
            };
            toastr.success('Success');
        },
        error: function () {
            toastr.options = {
                closeButton: true,
                progressBar: true,
                timeOut: 1000,
                positionClass: 'toast-bottom-right',
                onShown: function () {
                    const toast = document.querySelector('.toast-bottom-right');
                }
            };
            toastr.error('Error');
        }
    });
}