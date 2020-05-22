import React, { Component, Fragment } from 'react';
import { NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import authService from './AuthorizeService';
import { ApplicationPaths } from './ApiAuthorizationConstants';

import { GetUserData } from '../../State/Actions';
import { connect } from 'react-redux';
import { Dispatch, AnyAction } from 'redux';
import { ThunkDispatch } from 'redux-thunk';

interface IProps {    
    GetUserData: () => void;
}

interface IState {
    isAuthenticated: boolean,
    userName: string | null
}

interface IPath {
    pathname: string,
    state: IPathState
}

interface IPathState {
    local: boolean
}

class LoginMenu extends Component<IProps, IState> {
    private _subscription: number = 0;

    constructor(props: IProps) {
        super(props);

        this.state = {
            isAuthenticated: false,
            userName: null
        };
    }

    componentDidMount() {
        this._subscription = authService.subscribe(() => this.populateState());
        this.populateState();
    }

    componentWillUnmount() {
        authService.unsubscribe(this._subscription);
    }

    async populateState() {        
        const isAuthenticated = await authService.isAuthenticated();
        const user = await authService.getUser();

        console.log(isAuthenticated);
        console.log(user);

        this.setState({
            isAuthenticated,
            userName: user && user.name
        });                

        if (isAuthenticated) {
            console.log('Authenticated - call GetUserData')
            this.props.GetUserData();
        }
    }

    render() {       
        const { isAuthenticated, userName } = this.state;
        if (!isAuthenticated) {
            const registerPath = `${ApplicationPaths.Register}`;
            const loginPath = `${ApplicationPaths.Login}`;
            return this.anonymousView(registerPath, loginPath);
        } else {
            const profilePath = `${ApplicationPaths.Profile}`;
            const logoutPath : IPath = { pathname: `${ApplicationPaths.LogOut}`, state: { local: true } };
            return this.authenticatedView(userName, profilePath, logoutPath);
        }
       
    }

    authenticatedView(userName: string | null, profilePath: string, logoutPath: IPath) {
        return (<Fragment>
            <NavItem className="custom-nav">
                <NavLink tag={Link} className="text-dark" to={profilePath}>Hello {userName}</NavLink>
            </NavItem>
            <NavItem className="custom-nav">
                <NavLink tag={Link} className="text-dark" to={logoutPath}>Logout</NavLink>
            </NavItem>
        </Fragment>);

    }

    anonymousView(registerPath: string, loginPath: string) {        

        return (<Fragment>
            <NavItem className="custom-nav">
                <NavLink tag={Link} className="text-dark" to={registerPath}>Register</NavLink>
            </NavItem>
            <NavItem className="custom-nav">
                <NavLink tag={Link} className="text-dark" to={loginPath}>Login</NavLink>
            </NavItem>
        </Fragment>);        
    }
}

const mapDispatchToProps = (dispatch: ThunkDispatch<any, any, AnyAction>) => {
    console.log('mapDispatchToProps');
      
    return {
        GetUserData: () => dispatch(GetUserData())
    };
}
  
export default connect(null, mapDispatchToProps)(LoginMenu);
  
