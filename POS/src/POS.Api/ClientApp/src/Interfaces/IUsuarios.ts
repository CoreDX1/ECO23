export interface IUsuario {
    isSuccess: boolean;
    message:   string;
    data:      Data[];
}

export interface IUserById{
    isSuccess: boolean;
    message:   string;
    data:      Data;
}

export interface Data {
    idUser:           number;
    name:             string;
    paternalLastName: string;
    maternalLastName: string;
    cellPhone:        string;
    userPermissions:  UserPermissions;
    userProfile:      UserProfile;
}

export interface UserPermissions {
    idUserPermission: number;
    idUserEco:        number;
    idUserStatus:     number;
}

export interface UserProfile {
    idUser:       number;
    email:        string;
    userPassword: string;
    creationDate: Date;
    location:     Location;
}

export interface Location {
    street:   string;
    province: Province;
}

export interface Province {
    idProvince:    number;
    name:          string;
    userLocations: any[];
}