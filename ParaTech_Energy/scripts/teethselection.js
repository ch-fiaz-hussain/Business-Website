
$('#UpperJaw').on('change', function () {
    if ($(this).is(':checked')) {
        $("#Tooth11,#Tooth12,#Tooth13,#Tooth14,#Tooth15,#Tooth16,#Tooth17,#Tooth18,#Tooth21,#Tooth22,#Tooth23,#Tooth24,#Tooth25,#Tooth26,#Tooth27,#Tooth28").css('fill', "#2196f3");
    } else {
        $("#Tooth11,#Tooth12,#Tooth13,#Tooth14,#Tooth15,#Tooth16,#Tooth17,#Tooth18,#Tooth21,#Tooth22,#Tooth23,#Tooth24,#Tooth25,#Tooth26,#Tooth27,#Tooth28").css('fill', "#fff");
    }
})
$('#LowerJaw').on('change', function () {
    if ($(this).is(':checked')) {
        $("#Tooth31,#Tooth32,#Tooth33,#Tooth34,#Tooth35,#Tooth36,#Tooth37,#Tooth38,#Tooth41,#Tooth42,#Tooth43,#Tooth44,#Tooth45,#Tooth46,#Tooth47,#Tooth48").css('fill', "#2196f3");
    } else {
        $("#Tooth31,#Tooth32,#Tooth33,#Tooth34,#Tooth35,#Tooth36,#Tooth37,#Tooth38,#Tooth41,#Tooth42,#Tooth43,#Tooth44,#Tooth45,#Tooth46,#Tooth47,#Tooth48").css('fill', "#fff");
    }
})
$('#Complete').on('change', function () {
    if ($(this).is(':checked')) {
        $("#Tooth11,#Tooth12,#Tooth13,#Tooth14,#Tooth15,#Tooth16,#Tooth17,#Tooth18,#Tooth21,#Tooth22,#Tooth23,#Tooth24,#Tooth25,#Tooth26,#Tooth27,#Tooth28,#Tooth31,#Tooth32,#Tooth33,#Tooth34,#Tooth35,#Tooth36,#Tooth37,#Tooth38,#Tooth41,#Tooth42,#Tooth43,#Tooth44,#Tooth45,#Tooth46,#Tooth47,#Tooth48").css('fill', "#2196f3");
        $('#UpperJaw').prop('checked', true);
        $('#LowerJaw').prop('checked', true);
    } else {
        $("#Tooth11,#Tooth12,#Tooth13,#Tooth14,#Tooth15,#Tooth16,#Tooth17,#Tooth18,#Tooth21,#Tooth22,#Tooth23,#Tooth24,#Tooth25,#Tooth26,#Tooth27,#Tooth28,#Tooth31,#Tooth32,#Tooth33,#Tooth34,#Tooth35,#Tooth36,#Tooth37,#Tooth38,#Tooth41,#Tooth42,#Tooth43,#Tooth44,#Tooth45,#Tooth46,#Tooth47,#Tooth48").css('fill', "#fff");
        $('#UpperJaw').prop('checked', false);
        $('#LowerJaw').prop('checked', false);
    }
    
})
if ($('#Complete').is(':checked')) {
    $("#Tooth11,#Tooth12,#Tooth13,#Tooth14,#Tooth15,#Tooth16,#Tooth17,#Tooth18,#Tooth21,#Tooth22,#Tooth23,#Tooth24,#Tooth25,#Tooth26,#Tooth27,#Tooth28,#Tooth31,#Tooth32,#Tooth33,#Tooth34,#Tooth35,#Tooth36,#Tooth37,#Tooth38,#Tooth41,#Tooth42,#Tooth43,#Tooth44,#Tooth45,#Tooth46,#Tooth47,#Tooth48").css('fill', "#2196f3");
    $('#UpperJaw').prop('checked', true);
    $('#LowerJaw').prop('checked', true);
} else {
    $("#Tooth11,#Tooth12,#Tooth13,#Tooth14,#Tooth15,#Tooth16,#Tooth17,#Tooth18,#Tooth21,#Tooth22,#Tooth23,#Tooth24,#Tooth25,#Tooth26,#Tooth27,#Tooth28,#Tooth31,#Tooth32,#Tooth33,#Tooth34,#Tooth35,#Tooth36,#Tooth37,#Tooth38,#Tooth41,#Tooth42,#Tooth43,#Tooth44,#Tooth45,#Tooth46,#Tooth47,#Tooth48").css('fill', "#fff");
    $('#UpperJaw').prop('checked', false);
    $('#LowerJaw').prop('checked', false);
}
$('#LowerJaw').on('change', function () { 
    if ($("#LowerJaw").is(':checked') && $("#UpperJaw").is(':checked')) {
        $('#Complete').prop('checked', true);
    }
    else {
        $('#Complete').prop("checked", false);
    }
})
$('#UpperJaw').on('change', function () {
    if ($("#LowerJaw").is(':checked') && $("#UpperJaw").is(':checked')) {
        $('#Complete').prop('checked', true);
    }
    else {
        $('#Complete').prop("checked", false);
    }
})
 
//function Completeall() {
//    UpperJawall();
//    LowerJawall();
//}
function LowerJawall() {
    if (document.getElementById("Tooth48check").checked == false) { document.getElementById("Tooth48check").checked = true; }
    else { document.getElementById("Tooth48check").checked = false; }

    if (document.getElementById("Tooth47check").checked == false) { document.getElementById("Tooth47check").checked = true;}
    else { document.getElementById("Tooth47check").checked = false; }

    if (document.getElementById("Tooth46check").checked == false) { document.getElementById("Tooth46check").checked = true; }
    else { document.getElementById("Tooth46check").checked = false; }

    if (document.getElementById("Tooth45check").checked == false) { document.getElementById("Tooth45check").checked = true; }
    else { document.getElementById("Tooth45check").checked = false; }

    if (document.getElementById("Tooth44check").checked == false) { document.getElementById("Tooth44check").checked = true; }
    else { document.getElementById("Tooth44check").checked = false; }

    if (document.getElementById("Tooth43check").checked == false) { document.getElementById("Tooth43check").checked = true; }
    else { document.getElementById("Tooth43check").checked = false; }

    if (document.getElementById("Tooth42check").checked == false) { document.getElementById("Tooth42check").checked = true; }
    else { document.getElementById("Tooth42check").checked = false; }

    if (document.getElementById("Tooth41check").checked == false) { document.getElementById("Tooth41check").checked = true; }
    else { document.getElementById("Tooth41check").checked = false; }

    if (document.getElementById("Tooth38check").checked == false) { document.getElementById("Tooth38check").checked = true; }
    else { document.getElementById("Tooth38check").checked = false; }

    if (document.getElementById("Tooth37check").checked == false) { document.getElementById("Tooth37check").checked = true; }
    else { document.getElementById("Tooth37check").checked = false; }

    if (document.getElementById("Tooth36check").checked == false) { document.getElementById("Tooth36check").checked = true; }
    else { document.getElementById("Tooth36check").checked = false; }

    if (document.getElementById("Tooth35check").checked == false) { document.getElementById("Tooth35check").checked = true; }
    else { document.getElementById("Tooth35check").checked = false; }

    if (document.getElementById("Tooth34check").checked == false) { document.getElementById("Tooth34check").checked = true; }
    else { document.getElementById("Tooth34check").checked = false; }

    if (document.getElementById("Tooth33check").checked == false) { document.getElementById("Tooth33check").checked = true; }
    else { document.getElementById("Tooth33check").checked = false; }

    if (document.getElementById("Tooth32check").checked == false) { document.getElementById("Tooth32check").checked = true; }
    else { document.getElementById("Tooth32check").checked = false; }

    if (document.getElementById("Tooth31check").checked == false) { document.getElementById("Tooth31check").checked = true; }
    else { document.getElementById("Tooth31check").checked = false; }
    getValueUsingClass();
};
function UpperJawall() {
    if (document.getElementById("Tooth18check").checked == false) { document.getElementById("Tooth18check").checked = true; }
    else { document.getElementById("Tooth18check").checked = false; }

    if (document.getElementById("Tooth17check").checked == false) { document.getElementById("Tooth17check").checked = true; }
    else { document.getElementById("Tooth17check").checked = false; }

    if (document.getElementById("Tooth16check").checked == false) { document.getElementById("Tooth16check").checked = true; }
    else { document.getElementById("Tooth16check").checked = false; }

    if (document.getElementById("Tooth15check").checked == false) { document.getElementById("Tooth15check").checked = true; }
    else { document.getElementById("Tooth15check").checked = false; }

    if (document.getElementById("Tooth14check").checked == false) { document.getElementById("Tooth14check").checked = true; }
    else { document.getElementById("Tooth14check").checked = false; }

    if (document.getElementById("Tooth13check").checked == false) { document.getElementById("Tooth13check").checked = true; }
    else { document.getElementById("Tooth13check").checked = false; }

    if (document.getElementById("Tooth12check").checked == false) { document.getElementById("Tooth12check").checked = true; }
    else { document.getElementById("Tooth12check").checked = false; }

    if (document.getElementById("Tooth11check").checked == false) { document.getElementById("Tooth11check").checked = true; }
    else { document.getElementById("Tooth11check").checked = false; }

    if (document.getElementById("Tooth28check").checked == false) { document.getElementById("Tooth28check").checked = true; }
    else { document.getElementById("Tooth28check").checked = false; }

    if (document.getElementById("Tooth27check").checked == false) { document.getElementById("Tooth27check").checked = true; }
    else { document.getElementById("Tooth27check").checked = false; }

    if (document.getElementById("Tooth26check").checked == false) { document.getElementById("Tooth26check").checked = true; }
    else { document.getElementById("Tooth26check").checked = false; }

    if (document.getElementById("Tooth25check").checked == false) { document.getElementById("Tooth25check").checked = true; }
    else { document.getElementById("Tooth25check").checked = false; }

    if (document.getElementById("Tooth24check").checked == false) { document.getElementById("Tooth24check").checked = true; }
    else { document.getElementById("Tooth24check").checked = false; }

    if (document.getElementById("Tooth23check").checked == false) { document.getElementById("Tooth23check").checked = true; }
    else { document.getElementById("Tooth23check").checked = false; }

    if (document.getElementById("Tooth22check").checked == false) { document.getElementById("Tooth22check").checked = true; }
    else { document.getElementById("Tooth22check").checked = false; }

    if (document.getElementById("Tooth21check").checked == false) { document.getElementById("Tooth21check").checked = true; }
    else { document.getElementById("Tooth21check").checked = false; }
    getValueUsingClass();
};
function Completeall() {
    if (document.getElementById("Tooth18check").checked == false) { document.getElementById("Tooth18check").checked = true; }
    else { document.getElementById("Tooth18check").checked = false; }

    if (document.getElementById("Tooth17check").checked == false) { document.getElementById("Tooth17check").checked = true; }
    else { document.getElementById("Tooth17check").checked = false; }

    if (document.getElementById("Tooth16check").checked == false) { document.getElementById("Tooth16check").checked = true; }
    else { document.getElementById("Tooth16check").checked = false; }

    if (document.getElementById("Tooth15check").checked == false) { document.getElementById("Tooth15check").checked = true; }
    else { document.getElementById("Tooth15check").checked = false; }

    if (document.getElementById("Tooth14check").checked == false) { document.getElementById("Tooth14check").checked = true; }
    else { document.getElementById("Tooth14check").checked = false; }

    if (document.getElementById("Tooth13check").checked == false) { document.getElementById("Tooth13check").checked = true; }
    else { document.getElementById("Tooth13check").checked = false; }

    if (document.getElementById("Tooth12check").checked == false) { document.getElementById("Tooth12check").checked = true; }
    else { document.getElementById("Tooth12check").checked = false; }

    if (document.getElementById("Tooth11check").checked == false) { document.getElementById("Tooth11check").checked = true; }
    else { document.getElementById("Tooth11check").checked = false; }

    if (document.getElementById("Tooth28check").checked == false) { document.getElementById("Tooth28check").checked = true; }
    else { document.getElementById("Tooth28check").checked = false; }

    if (document.getElementById("Tooth27check").checked == false) { document.getElementById("Tooth27check").checked = true; }
    else { document.getElementById("Tooth27check").checked = false; }

    if (document.getElementById("Tooth26check").checked == false) { document.getElementById("Tooth26check").checked = true; }
    else { document.getElementById("Tooth26check").checked = false; }

    if (document.getElementById("Tooth25check").checked == false) { document.getElementById("Tooth25check").checked = true; }
    else { document.getElementById("Tooth25check").checked = false; }

    if (document.getElementById("Tooth24check").checked == false) { document.getElementById("Tooth24check").checked = true; }
    else { document.getElementById("Tooth24check").checked = false; }

    if (document.getElementById("Tooth23check").checked == false) { document.getElementById("Tooth23check").checked = true; }
    else { document.getElementById("Tooth23check").checked = false; }

    if (document.getElementById("Tooth22check").checked == false) { document.getElementById("Tooth22check").checked = true; }
    else { document.getElementById("Tooth22check").checked = false; }

    if (document.getElementById("Tooth21check").checked == false) { document.getElementById("Tooth21check").checked = true; }
    else { document.getElementById("Tooth21check").checked = false; }

    if (document.getElementById("Tooth48check").checked == false) { document.getElementById("Tooth48check").checked = true; }
    else { document.getElementById("Tooth48check").checked = false; }

    if (document.getElementById("Tooth47check").checked == false) { document.getElementById("Tooth47check").checked = true; }
    else { document.getElementById("Tooth47check").checked = false; }

    if (document.getElementById("Tooth46check").checked == false) { document.getElementById("Tooth46check").checked = true; }
    else { document.getElementById("Tooth46check").checked = false; }

    if (document.getElementById("Tooth45check").checked == false) { document.getElementById("Tooth45check").checked = true; }
    else { document.getElementById("Tooth45check").checked = false; }

    if (document.getElementById("Tooth44check").checked == false) { document.getElementById("Tooth44check").checked = true; }
    else { document.getElementById("Tooth44check").checked = false; }

    if (document.getElementById("Tooth43check").checked == false) { document.getElementById("Tooth43check").checked = true; }
    else { document.getElementById("Tooth43check").checked = false; }

    if (document.getElementById("Tooth42check").checked == false) { document.getElementById("Tooth42check").checked = true; }
    else { document.getElementById("Tooth42check").checked = false; }

    if (document.getElementById("Tooth41check").checked == false) { document.getElementById("Tooth41check").checked = true; }
    else { document.getElementById("Tooth41check").checked = false; }

    if (document.getElementById("Tooth38check").checked == false) { document.getElementById("Tooth38check").checked = true; }
    else { document.getElementById("Tooth38check").checked = false; }

    if (document.getElementById("Tooth37check").checked == false) { document.getElementById("Tooth37check").checked = true; }
    else { document.getElementById("Tooth37check").checked = false; }

    if (document.getElementById("Tooth36check").checked == false) { document.getElementById("Tooth36check").checked = true; }
    else { document.getElementById("Tooth36check").checked = false; }

    if (document.getElementById("Tooth35check").checked == false) { document.getElementById("Tooth35check").checked = true; }
    else { document.getElementById("Tooth35check").checked = false; }

    if (document.getElementById("Tooth34check").checked == false) { document.getElementById("Tooth34check").checked = true; }
    else { document.getElementById("Tooth34check").checked = false; }

    if (document.getElementById("Tooth33check").checked == false) { document.getElementById("Tooth33check").checked = true; }
    else { document.getElementById("Tooth33check").checked = false; }

    if (document.getElementById("Tooth32check").checked == false) { document.getElementById("Tooth32check").checked = true; }
    else { document.getElementById("Tooth32check").checked = false; }

    if (document.getElementById("Tooth31check").checked == false) { document.getElementById("Tooth31check").checked = true; }
    else { document.getElementById("Tooth31check").checked = false; }
    getValueUsingClass();
}

$(function () {
    $("#WithoutJaw").click(function () {
        if ($(this).is(":checked")) {
            $(".tooth-chart").addClass("divdisabled");
            $("#UpperJaw").attr('disabled', true);
            $("#LowerJaw").attr('disabled', true);
            $("#Complete").attr('disabled', true);
            var char = document.getElementById('Charges').value;
            document.getElementById('TotalCharges').value = char;
        } else {
            $(".tooth-chart").removeClass("divdisabled");
            $("#UpperJaw").attr('disabled', false);
            $("#LowerJaw").attr('disabled', false);
            $("#Complete").attr('disabled', false);
        }
    });
});
//Lower Jaw Right
function check48() {
    if (document.getElementById("Tooth48check").checked == false) {document.getElementById("Tooth48check").checked = true; document.getElementById("Tooth48").style.fill = "#2196f3";}
    else {document.getElementById("Tooth48check").checked = false; document.getElementById("Tooth48").style.fill = "#fff";}
    getValueUsingClass();
};
function check47() {
    if (document.getElementById("Tooth47check").checked == false) {
        document.getElementById("Tooth47check").checked = true;
        document.getElementById("Tooth47").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth47check").checked = false;
        document.getElementById("Tooth47").style.fill = "#fff";
    }
    getValueUsingClass();
};
function check46() {
    if (document.getElementById("Tooth46check").checked == false) {
        document.getElementById("Tooth46check").checked = true;
        document.getElementById("Tooth46").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth46check").checked = false;
        document.getElementById("Tooth46").style.fill = "#fff";
    }
    getValueUsingClass();
};
function check45() {
    if (document.getElementById("Tooth45check").checked == false) {
        document.getElementById("Tooth45check").checked = true;
        document.getElementById("Tooth45").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth45check").checked = false;
        document.getElementById("Tooth45").style.fill = "#fff";
    }
    getValueUsingClass();
};
function check44() {
    if (document.getElementById("Tooth44check").checked == false) {
        document.getElementById("Tooth44check").checked = true;
        document.getElementById("Tooth44").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth44check").checked = false;
        document.getElementById("Tooth44").style.fill = "#fff";
    }
    getValueUsingClass();
};
function check43() {
    if (document.getElementById("Tooth43check").checked == false) {
        document.getElementById("Tooth43check").checked = true;
        document.getElementById("Tooth43").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth43check").checked = false;
        document.getElementById("Tooth43").style.fill = "#fff";
    }
    getValueUsingClass();
};
function check42() {
    if (document.getElementById("Tooth42check").checked == false) {
        document.getElementById("Tooth42check").checked = true;
        document.getElementById("Tooth42").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth42check").checked = false;
        document.getElementById("Tooth42").style.fill = "#fff";
    }
    getValueUsingClass();
};
function check41() {
    if (document.getElementById("Tooth41check").checked == false) {
        document.getElementById("Tooth41check").checked = true;
        document.getElementById("Tooth41").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth41check").checked = false;
        document.getElementById("Tooth41").style.fill = "#fff";
    }
    getValueUsingClass();
};
//Lower Jaw Left
function check31() {
    if (document.getElementById("Tooth31check").checked == false) {
        document.getElementById("Tooth31check").checked = true;
        document.getElementById("Tooth31").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth31check").checked = false;
        document.getElementById("Tooth31").style.fill = "#fff";
    }
    getValueUsingClass();
};
function check32() {
    if (document.getElementById("Tooth32check").checked == false) {
        document.getElementById("Tooth32check").checked = true;
        document.getElementById("Tooth32").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth32check").checked = false;
        document.getElementById("Tooth32").style.fill = "#fff";
    }
    getValueUsingClass();
};
function check33() {
    if (document.getElementById("Tooth33check").checked == false) {
        document.getElementById("Tooth33check").checked = true;
        document.getElementById("Tooth33").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth33check").checked = false;
        document.getElementById("Tooth33").style.fill = "#fff";
    }
    getValueUsingClass();
};
function check34() {
    if (document.getElementById("Tooth34check").checked == false) {
        document.getElementById("Tooth34check").checked = true;
        document.getElementById("Tooth34").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth34check").checked = false;
        document.getElementById("Tooth34").style.fill = "#fff";
    }
    getValueUsingClass();
};
function check35() {
    if (document.getElementById("Tooth35check").checked == false) {
        document.getElementById("Tooth35check").checked = true;
        document.getElementById("Tooth35").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth35check").checked = false;
        document.getElementById("Tooth35").style.fill = "#fff";
    }
    getValueUsingClass();
};
function check36() {
    if (document.getElementById("Tooth36check").checked == false) {
        document.getElementById("Tooth36check").checked = true;
        document.getElementById("Tooth36").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth36check").checked = false;
        document.getElementById("Tooth36").style.fill = "#fff";
    }
    getValueUsingClass();
};
function check37() {
    if (document.getElementById("Tooth37check").checked == false) {
        document.getElementById("Tooth37check").checked = true;
        document.getElementById("Tooth37").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth37check").checked = false;
        document.getElementById("Tooth37").style.fill = "#fff";
    }
    getValueUsingClass();
};
function check38() {
    if (document.getElementById("Tooth38check").checked == false) {
        document.getElementById("Tooth38check").checked = true;
        document.getElementById("Tooth38").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth38check").checked = false;
        document.getElementById("Tooth38").style.fill = "#fff";
    }
    getValueUsingClass();
};
//Upper Jaw Left
function check28() {
    if (document.getElementById("Tooth28check").checked == false) {
        document.getElementById("Tooth28check").checked = true;
        document.getElementById("Tooth28").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth28check").checked = false;
        document.getElementById("Tooth28").style.fill = "#fff";
    }
    getValueUsingClass();
};
function check27() {
    if (document.getElementById("Tooth27check").checked == false) {
        document.getElementById("Tooth27check").checked = true;
        document.getElementById("Tooth27").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth27check").checked = false;
        document.getElementById("Tooth27").style.fill = "#fff";
    }
    getValueUsingClass();
};
function check26() {
    if (document.getElementById("Tooth26check").checked == false) {
        document.getElementById("Tooth26check").checked = true;
        document.getElementById("Tooth26").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth26check").checked = false;
        document.getElementById("Tooth26").style.fill = "#fff";
    }
    getValueUsingClass();
};
function check25() {
    if (document.getElementById("Tooth25check").checked == false) {
        document.getElementById("Tooth25check").checked = true;
        document.getElementById("Tooth25").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth25check").checked = false;
        document.getElementById("Tooth25").style.fill = "#fff";
    }
    getValueUsingClass();
};
function check24() {
    if (document.getElementById("Tooth24check").checked == false) {
        document.getElementById("Tooth24check").checked = true;
        document.getElementById("Tooth24").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth24check").checked = false;
        document.getElementById("Tooth24").style.fill = "#fff";
    }
    getValueUsingClass();
};
function check23() {
    if (document.getElementById("Tooth23check").checked == false) {
        document.getElementById("Tooth23check").checked = true;
        document.getElementById("Tooth23").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth23check").checked = false;
        document.getElementById("Tooth23").style.fill = "#fff";
    } getValueUsingClass();
};
function check22() {
    if (document.getElementById("Tooth22check").checked == false) {
        document.getElementById("Tooth22check").checked = true;
        document.getElementById("Tooth22").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth22check").checked = false;
        document.getElementById("Tooth22").style.fill = "#fff";
    } getValueUsingClass();
};
function check21() {
    if (document.getElementById("Tooth21check").checked == false) {
        document.getElementById("Tooth21check").checked = true;
        document.getElementById("Tooth21").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth21check").checked = false;
        document.getElementById("Tooth21").style.fill = "#fff";
    }
    getValueUsingClass();
};
//Upper Jaw Right
function check11() {
    if (document.getElementById("Tooth11check").checked == false) {
        document.getElementById("Tooth11check").checked = true;
        document.getElementById("Tooth11").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth11check").checked = false;
        document.getElementById("Tooth11").style.fill = "#fff";
    }
    getValueUsingClass();
};
function check12() {
    if (document.getElementById("Tooth12check").checked == false) {
        document.getElementById("Tooth12check").checked = true;
        document.getElementById("Tooth12").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth12check").checked = false;
        document.getElementById("Tooth12").style.fill = "#fff";
    }
    getValueUsingClass();
};
function check13() {
    if (document.getElementById("Tooth13check").checked == false) {
        document.getElementById("Tooth13check").checked = true;
        document.getElementById("Tooth13").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth13check").checked = false;
        document.getElementById("Tooth13").style.fill = "#fff";
    }
    getValueUsingClass();
};
function check14() {
    if (document.getElementById("Tooth14check").checked == false) {
        document.getElementById("Tooth14check").checked = true;
        document.getElementById("Tooth14").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth14check").checked = false;
        document.getElementById("Tooth14").style.fill = "#fff";
    }
    getValueUsingClass();
};
function check15() {
    if (document.getElementById("Tooth15check").checked == false) {
        document.getElementById("Tooth15check").checked = true;
        document.getElementById("Tooth15").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth15check").checked = false;
        document.getElementById("Tooth15").style.fill = "#fff";
    }
    getValueUsingClass();
};
function check16() {
    if (document.getElementById("Tooth16check").checked == false) {
        document.getElementById("Tooth16check").checked = true;
        document.getElementById("Tooth16").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth16check").checked = false;
        document.getElementById("Tooth16").style.fill = "#fff";
    }
    getValueUsingClass();
};
function check17() {
    if (document.getElementById("Tooth17check").checked == false) {
        document.getElementById("Tooth17check").checked = true;
        document.getElementById("Tooth17").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth17check").checked = false;
        document.getElementById("Tooth17").style.fill = "#fff";
    }
    getValueUsingClass();
};
function check18() {
    if (document.getElementById("Tooth18check").checked == false) {
        document.getElementById("Tooth18check").checked = true;
        document.getElementById("Tooth18").style.fill = "#2196f3";
    }
    else {
        document.getElementById("Tooth18check").checked = false;
        document.getElementById("Tooth18").style.fill = "#fff";
    }
    getValueUsingClass();
};



/* if the page has been fully loaded we add two click handlers to the button */
$(document).ready(function () {
    /* Get the checkboxes values based on the class attached to each check box */
    $("#buttonClass").click(function () {
        getValueUsingClass();
    });

    /* Get the checkboxes values based on the parent div id */
    $("#buttonParent").click(function () {
        getValueUsingParentTag();
    });
});

function getValueUsingClass() {
    /* declare an checkbox array */
    var chkArray = [];

    /* look for all checkboes that have a class 'chk' attached to it and check if it was checked */
    $(".chk:checked").each(function () {
        chkArray.push($(this).val());
    });

    /* we join the array separated by the comma */
    var selected;
    selected = chkArray.join(',');
    document.getElementById('teethtxt').value = selected
    //alert(chkArray.length);
    if ($("#pricetypetxt").val() == "Unit Wise") {
        var char = document.getElementById('Charges').value * chkArray.length;
        document.getElementById('TotalCharges').value = char;
        document.getElementById('totalchar').value = char;
    }
    if ($("#pricetypetxt").val() == "Complete") {
        var char = document.getElementById('Charges').value;
        document.getElementById('TotalCharges').value = char;
        document.getElementById('totalchar').value = char;
    }
    if ($("#pricetypetxt").val() == "Single Jaw") {
    var jaw = 0;
        if ($('#UpperJaw').is(':checked')) {
            jaw +=1;
        }
        else {
            jaw += 0;
        }
        if ($('#LowerJaw').is(':checked')) {
            jaw +=1;
        }
        else {
            jaw += 0;
        }
        var char = document.getElementById('Charges').value * jaw;
        document.getElementById('TotalCharges').value = char;
        document.getElementById('totalchar').value = char;
    }
}
    var teeth = document.getElementById('teethtxt').value
    var my_array = teeth.split(",");
    for (var i = 0; i < my_array.length; i++) {
        if (my_array[i] == "11") { $("#Tooth11").css('fill', "#2196f3"); document.getElementById("Tooth11check").checked = true;}
        if (my_array[i] == "12") { $("#Tooth12").css('fill', "#2196f3"); document.getElementById("Tooth12check").checked = true;}
        if (my_array[i] == "13") { $("#Tooth13").css('fill', "#2196f3"); document.getElementById("Tooth13check").checked = true;}
        if (my_array[i] == "14") { $("#Tooth14").css('fill', "#2196f3"); document.getElementById("Tooth14check").checked = true;}
        if (my_array[i] == "15") { $("#Tooth15").css('fill', "#2196f3"); document.getElementById("Tooth15check").checked = true;}
        if (my_array[i] == "16") { $("#Tooth16").css('fill', "#2196f3"); document.getElementById("Tooth16check").checked = true;}
        if (my_array[i] == "17") { $("#Tooth17").css('fill', "#2196f3"); document.getElementById("Tooth17check").checked = true;}
        if (my_array[i] == "18") { $("#Tooth18").css('fill', "#2196f3"); document.getElementById("Tooth18check").checked = true;}
        if (my_array[i] == "21") { $("#Tooth21").css('fill', "#2196f3"); document.getElementById("Tooth21check").checked = true;}
        if (my_array[i] == "22") { $("#Tooth22").css('fill', "#2196f3"); document.getElementById("Tooth22check").checked = true;}
        if (my_array[i] == "23") { $("#Tooth23").css('fill', "#2196f3"); document.getElementById("Tooth23check").checked = true;}
        if (my_array[i] == "24") { $("#Tooth24").css('fill', "#2196f3"); document.getElementById("Tooth24check").checked = true;}
        if (my_array[i] == "25") { $("#Tooth25").css('fill', "#2196f3"); document.getElementById("Tooth25check").checked = true;}
        if (my_array[i] == "26") { $("#Tooth26").css('fill', "#2196f3"); document.getElementById("Tooth26check").checked = true;}
        if (my_array[i] == "27") { $("#Tooth27").css('fill', "#2196f3"); document.getElementById("Tooth27check").checked = true;}
        if (my_array[i] == "28") { $("#Tooth28").css('fill', "#2196f3"); document.getElementById("Tooth28check").checked = true;}
        if (my_array[i] == "31") { $("#Tooth31").css('fill', "#2196f3"); document.getElementById("Tooth31check").checked = true;}
        if (my_array[i] == "32") { $("#Tooth32").css('fill', "#2196f3"); document.getElementById("Tooth32check").checked = true;}
        if (my_array[i] == "33") { $("#Tooth33").css('fill', "#2196f3"); document.getElementById("Tooth33check").checked = true;}
        if (my_array[i] == "34") { $("#Tooth34").css('fill', "#2196f3"); document.getElementById("Tooth34check").checked = true;}
        if (my_array[i] == "35") { $("#Tooth35").css('fill', "#2196f3"); document.getElementById("Tooth35check").checked = true;}
        if (my_array[i] == "36") { $("#Tooth36").css('fill', "#2196f3"); document.getElementById("Tooth36check").checked = true;}
        if (my_array[i] == "37") { $("#Tooth37").css('fill', "#2196f3"); document.getElementById("Tooth37check").checked = true;}
        if (my_array[i] == "38") { $("#Tooth38").css('fill', "#2196f3"); document.getElementById("Tooth38check").checked = true;}
        if (my_array[i] == "41") { $("#Tooth41").css('fill', "#2196f3"); document.getElementById("Tooth41check").checked = true;}
        if (my_array[i] == "42") { $("#Tooth42").css('fill', "#2196f3"); document.getElementById("Tooth42check").checked = true;}
        if (my_array[i] == "43") { $("#Tooth43").css('fill', "#2196f3"); document.getElementById("Tooth43check").checked = true;}
        if (my_array[i] == "44") { $("#Tooth44").css('fill', "#2196f3"); document.getElementById("Tooth44check").checked = true;}
        if (my_array[i] == "45") { $("#Tooth45").css('fill', "#2196f3"); document.getElementById("Tooth45check").checked = true;}
        if (my_array[i] == "46") { $("#Tooth46").css('fill', "#2196f3"); document.getElementById("Tooth46check").checked = true;}
        if (my_array[i] == "47") { $("#Tooth47").css('fill', "#2196f3"); document.getElementById("Tooth47check").checked = true;}
        if (my_array[i] == "48") { $("#Tooth48").css('fill', "#2196f3"); document.getElementById("Tooth48check").checked = true;}

    }
// Page info


$(function () {
    $(".other").click(function () {
        if ($(this).is(":checked")) {
            $(".otheractive").show();
        } else {
            $(".otheractive").hide();
        }
    });
});
$(function () {
    $(".appointment").click(function () {
        if ($(this).is(":checked")) {
            $(".appoactive").hide();
        } else {
            $(".appoactive").show();
        }
    });
});
$('input[name="Shade"]').click(function () {
    if ($(this).attr("value") == "1") {
        $(".shade1").show();
        $(".shade2").hide();
        $(".shade3").hide();
    }
    if ($(this).attr("value") == "2") {
        $(".shade1").show();
        $(".shade2").show();
        $(".shade3").hide();
    }
    if ($(this).attr("value") == "3") {
        $(".shade1").show();
        $(".shade2").show();
        $(".shade3").show();
    }
    if ($(this).attr("value") == "No Shade") {
        $(".shade1").hide();
        $(".shade2").hide();
        $(".shade3").hide();
    }
    if ($(this).attr("value") == "Provide Later") {
        $(".shade1").hide();
        $(".shade2").hide();
        $(".shade3").hide();
    }
});

    if ($(".other").is(":checked")) {
        $(".otheractive").show();
    } else {
        $(".otheractive").hide();
    }
    if ($(".appointment").is(":checked")) {
        $(".appoactive").hide();
    } else {
        $(".appoactive").show();
    }
    if ($('input[name="Shade"]').attr("value") == "1") {
        $(".shade1").show();
        $(".shade2").hide();
        $(".shade3").hide();
    }
    if ($('input[name="Shade"]').attr("value") == "2") {
        $(".shade1").show();
        $(".shade2").show();
        $(".shade3").hide();
    }
    if ($('input[name="Shade"]').attr("value") == "3") {
        $(".shade1").show();
        $(".shade2").show();
        $(".shade3").show();
    }
    if ($('input[name="Shade"]').attr("value") == "No Shade") {
        $(".shade1").hide();
        $(".shade2").hide();
        $(".shade3").hide();
    }
    if ($('input[name="Shade"]').attr("value") == "Provide Later") {
        $(".shade1").hide();
        $(".shade2").hide();
        $(".shade3").hide();
    }