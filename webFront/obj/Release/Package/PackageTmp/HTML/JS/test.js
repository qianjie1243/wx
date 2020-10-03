var stud = /** @class */ (function () {
    function stud(name, sex, idnumber, status) {
        this.name = name;
        this.sex = sex;
        this.idnumber = idnumber;
        this.status = status;
    }
    ;
    stud.prototype.ges = function () {
        console.log(this.name);
    };
    return stud;
}());
;
var data = new stud("1231", 11, '123123', true);
data.ges();
//# sourceMappingURL=test.js.map