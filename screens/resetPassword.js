import React, { useState } from 'react';
import { View, TextInput, Text, TouchableOpacity, Button, Alert, StyleSheet, ImageBackground } from 'react-native';
import { FontAwesome } from '@expo/vector-icons';

const ResetPasswordScreen = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [passwordsMatch, setPasswordsMatch] = useState(false);

  const handleConfirmPassword = () => {
    if (password === confirmPassword) {
      setPasswordsMatch(true);
    } else {
      setPasswordsMatch(false);
    }
  };

  return (
    <ImageBackground source={require('../assets/homeBG.png')} style={styles.background}>
      <View style={styles.container}>
        <View style={styles.formContainer}>
          <TextInput
            style={styles.passwordInput}
            placeholder="Contraseña anterior"
          />
          <TextInput
              style={styles.passwordInput}
              placeholder="Nueva contraseña"
              value={password}
              secureTextEntry={true}
              onChangeText={setPassword}
            />
          <View style={styles.passwordContainer}>
          <TextInput
              style={styles.passwordInput}
              placeholder="Confirmar contraseña"
              value={confirmPassword}
              secureTextEntry={true}
              onChangeText={setConfirmPassword}
              onBlur={handleConfirmPassword}
            />
            {passwordsMatch ? (
            <FontAwesome name="check" size={24} color="green" />
          ) : (
            <FontAwesome name="times" size={24} color="red" />
          )}
          </View>
          
          
          <TouchableOpacity style={styles.button} >
            <Text style={styles.buttonText}>Restablecer contraseña</Text>
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
    color: 'black', // Color del texto del botón
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
});

export default ResetPasswordScreen;
