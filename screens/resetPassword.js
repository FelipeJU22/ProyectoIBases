import React, { useState } from 'react';
import { View, TextInput, Button, StyleSheet, Text } from 'react-native';

const ResetPasswordScreen = () => {
  const [email, setEmail] = useState('');
  const [resetStatus, setResetStatus] = useState('');

  const handleResetPassword = () => {
    // Aquí iría tu lógica para enviar un correo de restablecimiento de contraseña
    // Por simplicidad, aquí solo mostramos un mensaje de éxito
    setResetStatus('Se ha enviado un correo de restablecimiento de contraseña a: ' + email);
  };

  return (
    <View style={styles.container}>
      <Text style={styles.title}>Restablecer Contraseña</Text>
      <TextInput
        style={styles.input}
        placeholder="Correo electrónico"
        onChangeText={setEmail}
        value={email}
        keyboardType="email-address"
        autoCapitalize="none"
      />
      <Button title="Restablecer Contraseña" onPress={handleResetPassword} />
      {resetStatus ? <Text style={styles.resetStatus}>{resetStatus}</Text> : null}
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    paddingHorizontal: 20,
  },
  title: {
    fontSize: 24,
    marginBottom: 20,
  },
  input: {
    width: '100%',
    marginBottom: 20,
    paddingVertical: 10,
    paddingHorizontal: 15,
    borderWidth: 1,
    borderColor: '#ccc',
    borderRadius: 5,
  },
  resetStatus: {
    marginTop: 20,
    color: 'green',
  },
});

export default ResetPasswordScreen;