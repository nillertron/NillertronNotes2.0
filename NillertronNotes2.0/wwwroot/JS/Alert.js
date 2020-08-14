function CloseAlert() {
    $(document).ready(function () {
        $('#myAlert').on('closed.bs.alert', function () {
            $().alert('close');
        })
    })
}
