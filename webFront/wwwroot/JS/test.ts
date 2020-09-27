

class stud {
    name: string;
    sex: number;
    idnumber: string;
    status: boolean;

    constructor(name: string, sex: number, idnumber: string, status: boolean) {
        this.name = name;
        this.sex = sex;
        this.idnumber = idnumber;
        this.status = status;
    };
    ges(): void {
        console.log(this.name);
    }
};

let data = new stud("1231", 11, '123123', true);
data.ges();