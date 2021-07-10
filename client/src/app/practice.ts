//variables in TS
let hello:string = "slimShady";

//functions in TS
//define the parameter type and return type as well
const printName = (firstName: string, lastName : string) : string =>
{
    return (firstName +" "+ lastName)
}

//function with void return tyoe
const printName2 = (firstName: string, lastName : string) : void =>
{
    console.log (firstName +" "+ lastName)
}

console.log(printName(hello, "world"))


//interface in TS
interface IUser{
userName: string,
age?: number,
showMessage():string

}

//createing object in TS
//this is how we give type to object values as objects use : for fields inside them not =

const ramesh : IUser = {
    userName:"ramesh",
    age:5,
    showMessage()
    { 
        return "hello " + this.userName;
    }
}


console.log(ramesh.showMessage())

//types are like sets in TS so we can combine them to create a new set.
//this is done using  | symbol 
//we can create  union for types and interfaces as wel
let errorMessage : string|null  = null;
let errorMessage2 : string|number|null  = 1;
let unionUsingDatatypeAndInterface : IUser|null = null;

//Custome Types
//Defining types by ourselves
type ID = string| number;

const valueId : ID = 5;

// we can define type to bring clarity to our type as wellt
type Rollno = number;

const studentNumbers : Rollno[] = [1,2,3,4] // here although the tag RollNumber is just a number 
//it clarifies that the studentNumber variable is an array of rollnumbers, hence bringing clarity


//Any and Unknown datatype
//DONT use any. use it as less as possible
///unknow is the better alternative to any, 
//it takes in value of any type but it can only be assigned to another unknown type variable
let valueAny : any = 10;
let valUnknown : unknown = 10;

let s1 : string = valueAny;//  No error ,      see below commented out code
//let s2 : string = valUnknown;//   ERROR 

valueAny.Foo() // no error
//valUnknown.Foo()// ERROR, 
//thus although initially we can assign whatervar value we want to unknown 
//it cannot be used like datatype any and is much safer to use.

//TypeAssertion or Type casting : changing dataype using "as"
let s2 : string = valUnknown as string

//for other datatypes
let pageNumber : number = 5;
//let s3 : number = pageNumber as number // ERROR, cannot directly convert to number, some types cannot be directly converted
//NOTE we can convert unknown or any datatypes directly
let s4 : number = (pageNumber as unknown) as number // convert to unknown tahn convert to desired datat type


//NOTE TYPE SCRIPT DOESNT HAVE ANY ACCESS TO OUR MARKUP, THUS WE NEED TO DEFINE THE CORECT TYPE OF
//OUR DOM ELEMENTS(using THE typecasting AS operaator ) BEFORE BEING ABLE TO USE THEM 
// SEE THIS PART FROM VIDEO

interface IWorker {
getFullName() : string;

}


//Classes in TS
class Employee implements IWorker
{
    // note private, public and other access moidifier are only present in tpe script not javascript
    // so we wont get the access modifier errror in runtime , we will only get in compile time using TS
    // we can use properties like static readonly
    private firstName : string;
    private lastName : string;
    static readonly maxAge = 55;

    constructor ( firstName : string,  lastName : string)
    {
        this.firstName = firstName;
        this.lastName = lastName;
    }

    getFullName(): string
    {
        return this.firstName + " " + this.lastName;
    }

}
    const empl = new Employee("lol","me");
    //console.log(empl.lastName);//  ERROR
    console.log(empl.getFullName()) // no error
    console.log(Employee.maxAge)// static property

    //Inheritence in TS

    class Programmer extends Employee
    {

    }

    const prog = new Programmer("Ram", "Hello");

    console.log(prog.getFullName());
    console.log(Programmer.maxAge);

    //Generic in TS

    interface IStudent
    {
        Name :  string;
        RollNo: number;
    }

    const tempStudent : IStudent = 
    {
        Name :  "Ramesh",
        RollNo: 80
    }
    
    const addId = <T>(val : T)  =>
    {
        return {
            ...val,
            ID : 1

        }
    }

    console.log( "result",addId<IStudent>(tempStudent))
              console.log( "result",addId<string>("abc"))// NO ERROR EVEN IF the INPUT IS STRING 

    // Setting up a default generic parameter for same implementation
    // we use "extends" to set up a default generic type 
    interface IStudent
    {
        Name :  string;
        RollNo: number;
    }

    const tempStudent2 : IStudent = 
    {
        Name :  "Ramesh",
        RollNo: 80
    }
    
    const addId2 = <T extends object>(val : T)  => // here T should now be an object, 
                                                //similar to where T : class in C#
    {
        return {
            ...val,
            ID : 1

        }
    }

    console.log( "result",addId2<IStudent>(tempStudent))
    //console.log( "result",addId2<string>("abc"))//  ERROR  INPUT IS STRING , as we used extends object in addID2
 

    // SIMILARLY we CAN ASIGN GENERIC INTERFACES

    interface IEmployee<T>
    {
        Name : String;
        data : T;

    }

    const emp1 : IEmployee<number> = 
    {
       Name : "hello",
        data : 5
    }

    const emp2 : IEmployee<number[]> = 
    {
       Name : "hello",
        data : [5,6,7,8,9]
    }
    // Advantage of generic interface, can be used with many data tyoes


    //ENUMS  in TS

    //main andvantages of enum is that we can use it as a datatype hence making the code very clear and understandable

    enum StatusEnum
    {
        Started,
        NotStarted,
        InProgress
    }

    let fileStatus : StatusEnum = StatusEnum.Started ///main andvantages of enum is that we can use it as a datatype
    //fileStatus = 2 // ERROR, We can assign values present in the enums only, so makes it faultproof
    fileStatus = StatusEnum.InProgress // no error



    enum Status2
    {
        Started = "Started",
        NotStarted = "Not Started",
        InProgress = "In Progress"
    }

    let fileStatus2 : Status2 = Status2.Started // we get string value "Started"
    //fileStatus2 = "Try" // ERROR, We can assign values present in the enums only, so makes it faultproof
    fileStatus2 = Status2.InProgress // no error



// EXTRAS
//      let msg ='hello bitches';
//  //console.log(msg);

//  //let isCorrect: boolean = true;
//  //let total: number = 987654321;
//  let name: string ="Pratyush";
//  let sentence:string = `My name is ${name}.
//  I am software engineer and a beginner in typescript.`
//  //console.log(sentence);

//  let arrStr: String[] =["ram","sam"]; 
//  //console.log(arrStr);
//  let tupNumStr: [Number, String] =[51,"pratyush"];
//  //console.log(tupNumStr);

//  enum Color{red,green,blue};
//  let c: Color = Color.green;
//  console.log(c);

// // use type any if you want dynamical value and dont know what the input type will be
// // type any is error prone as you dont get red wiggly below and others
// // with type any we can access all the properties of string numer and bool so if we assign a number to any type we can still use string properties(red wiggly wont come )which later will giv error
 
  
// // type unkmown is similar to any except we cant access the properties and construcor so we get errors
// // as is like type casting for C#

// let names: any ="hello"
// names=5
// console.log(names)

// let surname: unknown ="darkness";
// console.log((surname as string).toUpperCase());