import React, { useEffect, useState } from 'react';
import { View, TextInput, Text, TouchableOpacity, Button, Alert, StyleSheet, ImageBackground, FlatList } from 'react-native';
import { Feather } from '@expo/vector-icons'; // Importa los iconos de Feather (o cualquier otra biblioteca de iconos)
import { db} from '../DataBase_SQLite/DBTables'; // Importa la función para verificar y crear la base de datos
import md5 from 'md5';


const LoginScreen = ({ navigation }) => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [showPassword, setShowPassword] = useState(false); // Estado para controlar si se muestra la contraseña o no


  const handleTogglePasswordVisibility = () => {
    setShowPassword(!showPassword); // Cambia el estado para mostrar u ocultar la contraseña
  };

  const handleLogin = () => {
    const hashedPassword = cifrarPassword(password);
    db.transaction(tx => {
      tx.executeSql(
        'SELECT * FROM PROFESOR WHERE correo = ? AND password = ?',
        [email, hashedPassword],
        (tx, results) => {
          if (results.rows.length > 0) {
            navigation.navigate('Home', { email: email });
          } else {
            Alert.alert('Error', 'Correo o contraseña incorrectos');
          }
        },
        error => {
          console.error('Error al buscar el profesor en la base de datos:', error);
        }
      );
    });
  };

  const cifrarPassword = (password) => {
    return md5(password);
  }

  return (
    <ImageBackground source={require('../assets/loginBG.png')} style={styles.background}>
      <View style={styles.container}>
        <View style={styles.formContainer}>
          <TextInput
            style={styles.input}
            placeholder="Correo electrónico"
            onChangeText={setEmail}
            value={email}
            keyboardType="email-address"
            autoCapitalize="none"
          />
          <View style={styles.passwordContainer}>
            <TextInput
              style={styles.passwordInput}
              placeholder="Contraseña"
              onChangeText={setPassword}
              value={password}
              secureTextEntry={!showPassword} // Oculta la contraseña si showPassword es falso
            />
            <TouchableOpacity onPress={handleTogglePasswordVisibility} style={styles.toggleButton}>
              <Feather name={showPassword ? 'eye' : 'eye-off'} size={24} color="white" />
            </TouchableOpacity>
          </View>
          <TouchableOpacity style={styles.button} onPress={handleLogin}>
            <Text style={styles.buttonText}>Iniciar sesión</Text>
          </TouchableOpacity>
        </View>
      </View>
    </ImageBackground>
  );
};
const styles = StyleSheet.create({
  background: {
    flex: 1,
    resizeMode: 'cover', // Opcional, para ajustar la imagen de fondo a la pantalla
    justifyContent: 'center',
    backgroundColor: 'rgba(0,0,0,0.1)', // Opacidad del 80%
  },
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    paddingHorizontal: 20,
  },
  formContainer: {
    backgroundColor: 'rgba(0,0,0,0.5)', // Color de fondo semi-transparente
    borderRadius: 10,
    padding: 20,
    width: '90%',
    maxWidth: 400,
  },
  button: {
    backgroundColor: '#3D8E9C', // Color de fondo del botón
    borderRadius: 5,
    paddingVertical: 10,
    paddingHorizontal: 15,
    alignItems: 'center',
  },
  buttonText: {
    color: 'white', // Color del texto del botón
    fontSize: 19,
  },
  input: {
    width: '84%',
    marginBottom: 20,
    marginRight: 20,
    paddingVertical: 10,
    paddingHorizontal: 15,
    borderWidth: 1,
    borderColor: '#ccc',
    borderRadius: 5,
    backgroundColor: '#fff', // Color de fondo para que el texto sea legible
  },
  passwordContainer: {
    flexDirection: 'row',
    alignItems: 'center',
  },
  passwordInput: {
    width: '84%',
    marginBottom: 20,
    paddingVertical: 10,
    paddingHorizontal: 15,
    borderWidth: 1,
    borderColor: '#ccc',
    borderRadius: 5,
    backgroundColor: '#fff', // Color de fondo para que el texto sea legible
  },
  toggleButton: {
    padding: 10,
  },
});

export default LoginScreen;