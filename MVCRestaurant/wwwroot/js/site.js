// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function DeclareModal(containerId, ModalId, ModalBodyId, buttonId, TitleId, CloseModalId, ActionModalId) {
    $("#" + containerId)
        .html(
            `<div class=modal fade" id="${ModalId}" tabindex=" - 1" role="dialog" aria-labelledby="${ModalId}" aria-hidden="true">
        <div class= "modal-dialog modal-lg modal-dialog-centered" role="document" >
        <div class="modal-content">
            <div class="modal-header">
                <h5 id="${TitleId}" class="modal-title" style="margin: 0 auto;" id="ModalLongTitle"></h5>
            </div>
            <div id="${ModalBodyId}" class="p-3">
            </div>
            <div class="modal-footer ml-auto">
          <button id="${CloseModalId}" type="button" class="btn btn-secondary mr-2" data-bs-dismiss="modal">بستن</button>
          <button id="${ActionModalId}" type="button" class="btn btn-primary mr-2" onclick="$('#${buttonId}').click()">ذخیره تغییرات</button>
      </div>
    </div>
  </div>
</div>

<style>
    #${ModalBodyId} form .form-group{
        margin-top:6px;
        margin-bottom:6px
    }
</style>`)

    function EnhanceAjaxForm() {
        this.setAttribute("data-ajax", "true")
        this.setAttribute("data-ajax-dataType", "html")
        this.setAttribute("data-ajax-update", "#" + ModalBodyId)
        this.setAttribute("data-ajax-success", "DeclareModal.EnhanceAjaxForm.DataSuccess")
        this.setAttribute("data-ajax-failure", "DeclareModal.EnhanceAjaxForm.DataFailure")

        function DataSuccess(response) {
            //alert("success!");
            $("#" + ModalBodyId).html('<p dir="ltr" class="text-start">Finishing...</p>');
            $("#" + ModalId + " button").hide();
            ToastrSuccess()
            setTimeout(function () {
                $("#" + ModalId).modal('hide');
                location.replace(location.href);
            }, 2200)
        }
        EnhanceAjaxForm.DataSuccess = DataSuccess

        function DataFail(response) {
            ToastrFail()
            $("#" + ModalBodyId).html(response.responseText);
        }
        EnhanceAjaxForm.DataFailure = DataFail
    }

    DeclareModal.EnhanceAjaxForm = EnhanceAjaxForm;
}

