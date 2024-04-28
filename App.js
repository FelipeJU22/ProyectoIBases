import * as React from 'react';
import { Button, View, Text } from 'react-native';
import { NavigationContainer } from '@react-navigation/native';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import Login from './screens/login';
import Home from './screens/home';
import Account from './screens/resetPassword';



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
      <Stack.Screen name="Account" component={Account} options={{
            headerTransparent: true,
            headerTitle: '',
            headerStyle: {
              backgroundColor: 'transparent', // Fondo del encabezado transparente
              elevation: 0, // Elimina la sombra en Android
              shadowOpacity: 0, // Elimina la sombra en iOS
            },
            headerTintColor: '#fff', // Color del texto del encabezado
          }}/>
      </Stack.Navigator>
    </NavigationContainer>
  );
}

export default App;