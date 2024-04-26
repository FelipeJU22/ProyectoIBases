import * as React from 'react';
import { Button, View, Text } from 'react-native';
import { NavigationContainer } from '@react-navigation/native';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import Login from './screens/login';
import Home from './screens/home';



const Stack = createNativeStackNavigator();

function App() {
  return (
    <NavigationContainer>
      <Stack.Navigator>
        <Stack.Screen name="Login" component={Login} options={{ 
    title: "Ingresa tu cuenta", 
    headerStyle: { 
      backgroundColor: "#3D8E9C"
    },
    headerTintColor: "black"
  }}  />
      <Stack.Screen name="Home" component={Home} options={{
    headerShown: false
  }}/>
      </Stack.Navigator>
    </NavigationContainer>
  );
}

export default App;